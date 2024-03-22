using System;
using ABC971.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseAdd : ContentPage
    {
        private readonly int SelectedTermId;
        public CourseAdd()
        {
            InitializeComponent();
        }

        public CourseAdd(int termId)
        {
            InitializeComponent();
            SelectedTermId = termId;
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
        async void AddCourseButton_Clicked(object sender, EventArgs e)
        {
            bool emailInvalid = isInvalidEmail(InstrEmail.Text);
            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Course Name", "Ok");
                return;
            }

            if (CourseStatusSelector.SelectedItem == null || string.IsNullOrWhiteSpace(CourseStatusSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error", "Please Enter A Status", "Ok");
                return;
            }

            if (CourseStartSelector.Date >= CourseEndSelector.Date)
            {
                await DisplayAlert("Error", "Make Sure Course Start Date Is Before Course End Date", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(InstrName.Text))
            {
                await DisplayAlert("Error", "Please Enter An Instructor Name", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(InstrPhone.Text))
            {
                await DisplayAlert("Error", "Please Enter A Valid Instructor Phone Number", "Ok");
                return;
            }

            if (emailInvalid || string.IsNullOrWhiteSpace(InstrEmail.Text))
            {
                await DisplayAlert("Error", "Please Enter A Valid Instructor Email", "Ok");
                return;
            }

            await DatabaseServices.AddCourse(SelectedTermId, CourseName.Text, CourseStatusSelector.SelectedItem.ToString(),
                CourseStartSelector.Date, CourseEndSelector.Date, Alert.IsToggled, InstrName.Text,
                InstrPhone.Text, InstrEmail.Text, CourseNotes.Text);

            await DisplayAlert("Success", "Course Added Successfully", "Ok");
            await Navigation.PopAsync();


        }
    }
}

