using System;
using ABC971.Models;
using ABC971.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentAdd : ContentPage
    {
        private readonly int SelectedCourseId;

        public AssessmentAdd()
        {
            InitializeComponent();
        }

        public AssessmentAdd(int courseId)
        {
            InitializeComponent();
            SelectedCourseId = courseId;

        }

        async void AddNewAssessment_Clicked(object sender, EventArgs e)
        {
            var existingAssessments = DatabaseServices.GetAssessments(SelectedCourseId);
            bool typeExists = false;
            if (string.IsNullOrWhiteSpace(AssessmentName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Name", "Ok");
                return;
            }

            if (AssessmentTypeSelector.SelectedItem == null || string.IsNullOrWhiteSpace(AssessmentTypeSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error", "Please Select A Type", "Ok");
                return;
            }

            if (StartDateSelector.Date >= DueDateSelector.Date)
            {
                await DisplayAlert("Error", "End Date Must Not Precede Start Date ", "Ok");
                return;
            }

            foreach (Assessment assessment in await existingAssessments)
            {
                if (assessment.Type == AssessmentTypeSelector.SelectedItem.ToString())
                {
                    typeExists = true;
                }
            }

            if (typeExists)
            {
                await DisplayAlert("Invalid Information", $"Assessment type {AssessmentTypeSelector.SelectedItem} exists already", "OK");
                return;
            }
            else
            {
                await DatabaseServices.AddAssessment(SelectedCourseId, AssessmentName.Text,
                                     AssessmentTypeSelector.SelectedItem.ToString(), StartDateSelector.Date, DueDateSelector.Date, Alert.IsToggled);
                await DisplayAlert("Success", "Successfully Added Assessment", "Ok");
                await Navigation.PopAsync();
            }


        }
    }
}



