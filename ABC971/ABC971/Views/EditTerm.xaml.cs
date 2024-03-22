using System;
using System.Linq;
using ABC971.Models;
using ABC971.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTerm : ContentPage
    {
        private readonly int SelectedTermId;
        public EditTerm()
        {
            InitializeComponent();
        }

        public EditTerm(Term term)
        {
            InitializeComponent();

            SelectedTermId = term.ID;

            TermId.Text = term.ID.ToString();
            TermName.Text = term.Name;
            TermStatusSelector.SelectedItem = term.Status;
            TermStartSelector.Date = term.StartDate;
            TermEndSelector.Date = term.EndDate;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var courses = await DatabaseServices.GetCourses(SelectedTermId);
            int courseCount = courses.Count();
            courseCountLabel.Text = $"COURSE COUNT = \t{courseCount}";
            CourseCollectionView.ItemsSource = await DatabaseServices.GetCourses(SelectedTermId);
        }

        async void SaveTerm_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Name", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(TermStatusSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error: Missing Status", "Please Enter A Status", "Ok");
                return;
            }

            if (TermStartSelector.Date >= TermEndSelector.Date)
            {
                await DisplayAlert("Error:", "Start Date Must Be Before The End Date", "Ok");
                return;
            }

            await DatabaseServices.UpdateTerm(SelectedTermId, TermName.Text, TermStatusSelector.SelectedItem.ToString(),
                               TermStartSelector.Date, TermEndSelector.Date);

            await DisplayAlert("Success", "Updated Term Successfully!", "Ok");
            await Navigation.PopAsync();
        }

        async void DeleteTerm_Clicked(object sender, EventArgs e)
        {
            bool confirmDel = await DisplayAlert("Confirm?", "Delete The Selected Term And Its Courses?", "Yes", "No");
            var delRelatedCourse = await DatabaseServices.GetCourses(SelectedTermId);
            if (confirmDel)
            {
                foreach (var course in delRelatedCourse)
                {
                    await DatabaseServices.DeleteCourse(course.ID);
                }
                await DatabaseServices.DeleteTerm(SelectedTermId);
                await DisplayAlert("Success", "Deleted Term", "Ok");
            }
            else
            {
                await DisplayAlert("Success", "Canceled Delete Operation", "Ok");
            }

            await Navigation.PopAsync();

        }


        async void AddCourse_Clicked(object sender, EventArgs e)
        {
            var courses = await DatabaseServices.GetCourses(SelectedTermId);
            int courseCount = courses.Count();

            if (courseCount == 6)
            {
                await DisplayAlert("Error: Exceeded Maximum Amount of Courses", "A Term Can Only Have 6 Courses Max", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new CourseAdd(SelectedTermId));
            }

        }

        async void CourseCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Course course = (Course)e.CurrentSelection.FirstOrDefault();

            if (e.CurrentSelection != null)
            {
                await Navigation.PushAsync(new CourseEdit(course));
            }
        }
    }
}
