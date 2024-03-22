using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC971.Models;
using ABC971.Services;
using System;
using Xamarin.Essentials;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseEdit : ContentPage
    {
        private readonly int SelectedCourseId;
        public CourseEdit()
        {
            InitializeComponent();
        }

        public CourseEdit(Course course)
        {
            InitializeComponent();

            SelectedCourseId = course.ID;

            CourseId.Text = course.ID.ToString();
            CourseName.Text = course.Name;
            CourseStatusSelector.SelectedItem = course.Status;
            CourseStartSelector.Date = course.StartDate;
            CourseEndSelector.Date = course.EndDate;
            Alert.IsToggled = course.Alert;
            InstrName.Text = course.InstructorName;
            InstrPhone.Text = course.InstructorPhone;
            InstrEmail.Text = course.InstructorEmail;
            CourseNotes.Text = course.Notes;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

         
            AssessmentCollectionView.ItemsSource = await DatabaseServices.GetAssessments(SelectedCourseId);
        }

        private bool isInvalidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return !(addr.Address == email);
            }
            catch
            {
                return true;
            }
        }
        async void SaveCourse_Clicked(object sender, EventArgs e)
        {
            bool emailInvalid = isInvalidEmail(InstrEmail.Text);
            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Name", "Ok");
                return;
            }

            if (CourseStatusSelector.SelectedItem == null || string.IsNullOrWhiteSpace(CourseStatusSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error", "Please Enter A Status", "Ok");
                return;
            }

            if (CourseStartSelector.Date >= CourseEndSelector.Date)
            {
                await DisplayAlert("Error", "Start Date Must Be Before End Date", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(InstrName.Text))
            {
                await DisplayAlert("Error", "Make Sure To Enter Instructor Name", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(InstrPhone.Text))
            {
                await DisplayAlert("Error", "Make Sure To Enter Instructor Phone Number", "Ok");
                return;
            }

            if (emailInvalid || string.IsNullOrWhiteSpace(InstrEmail.Text))
            {
                await DisplayAlert("Error", "Make Sure To enter Instructor Email", "Ok");
                return;
            }

            await DatabaseServices.UpdateCourse(SelectedCourseId, CourseName.Text, CourseStatusSelector.SelectedItem.ToString(),
                CourseStartSelector.Date, CourseEndSelector.Date, Alert.IsToggled, InstrName.Text,
                InstrPhone.Text, InstrEmail.Text, CourseNotes.Text);
            await DisplayAlert("Test Button", "Updated Course Successfully!", "OK");
            await Navigation.PopAsync();
        }

        async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            bool confirmDel = await DisplayAlert("Confirm?", "Delete course?", "Yes", "No");
            var delRelatedAssessments = await DatabaseServices.GetAssessments(SelectedCourseId);
            if (confirmDel)
            {
                foreach (var assessment in delRelatedAssessments)
                {
                    await DatabaseServices.DeleteAssessment(assessment.ID);
                }

                await DatabaseServices.DeleteCourse(SelectedCourseId);
                await DisplayAlert("Success", "Course Deleted", "Ok");
            }
            else
            {
                await DisplayAlert("Success", "Canceled Deletion", "Ok");
            }

            await Navigation.PopAsync();
        }

        async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            var assessments = await DatabaseServices.GetAssessments(SelectedCourseId);
            int assessmentCount = assessments.Count();

            if (assessmentCount == 2)
            {
                await DisplayAlert("Unsuccessful", "A Course Can Only Have 2 Assessments Max", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new AssessmentAdd(SelectedCourseId));
            }

        }

        async void AssessmentCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Assessment assessment = (Assessment)e.CurrentSelection.FirstOrDefault();

            if (e.CurrentSelection != null)
            {
                await Navigation.PushAsync(new AssessmentEdit(assessment));
            }
        }

        async void ShareText_Clicked(object sender, EventArgs e)
        {
            string shareText = CourseNotes.Text;
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = shareText,
                Title = $"Share Notes for Course {CourseName.Text}"
            }); ;


        }

        async void ShareUri_Clicked(object sender, EventArgs e)
        {
            string shareText = CourseNotes.Text;
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = shareText,
                Title = $"Share Notes for Course {CourseName.Text}"
            });
        }

    }
}



