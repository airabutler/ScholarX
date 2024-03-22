using System;
using System.Linq;
using ABC971.Services;
using ABC971.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTerm());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var allTerms = await DatabaseServices.GetTerms();
            TermCollectionView.ItemsSource = allTerms;

            var courseList = await DatabaseServices.GetCourses();
            var assessmentList = await DatabaseServices.GetAssessments();

            int notificationId = 0;

            foreach (Course course in courseList)
            {
                if (course.Alert == true)
                {
                    if (course.StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notification", $"{course.Name} starts today!", notificationId);
                        notificationId++;
                    }

                    if (course.EndDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notification", $"{course.Name} ends today!", notificationId);
                        notificationId++;
                    }
                }
            }

            foreach (Assessment assessment in assessmentList)
            {
                if (assessment.Alert == true)
                {
                    if (assessment.StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notification", $"{assessment.Name} starts today!", notificationId);
                        notificationId++;
                    }
                    if (assessment.DueDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("Notification", $"{assessment.Name} due today!", notificationId);
                        notificationId++;
                    }
                }
            }

        }


        private async void TermCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new EditTerm(term));
            }
        }

        private async void ClearDataButton_Clicked(object sender, EventArgs e)
        {
            await DatabaseServices.ClearSampleData();
            await DisplayAlert("WARNING", "Cleared Example Data", "OK");

            var allTerms = await DatabaseServices.GetTerms();
            TermCollectionView.ItemsSource = allTerms;

        }

        private async void LoadDataButton_Clicked(object sender, EventArgs e)
        {
            await DatabaseServices.LoadSampleData();
            await DisplayAlert("WARNING", "Loaded Example Data", "OK");

            var allTerms = await DatabaseServices.GetTerms();
            TermCollectionView.ItemsSource = allTerms;

        }
    }
}
