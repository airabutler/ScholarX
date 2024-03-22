using System;
using ABC971.Models;
using ABC971.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentEdit: ContentPage
    {
        private readonly int SelectedAssessmentId;
        private readonly int SelectedCourseId;
        public AssessmentEdit()
        {
            InitializeComponent();
        }

        public AssessmentEdit(Assessment assessment)
        {
            InitializeComponent();

            SelectedAssessmentId = assessment.ID;
            SelectedCourseId = assessment.CourseID;
            AssessmentID.Text = assessment.ID.ToString();
            AssessmentName.Text = assessment.Name;
            AssessmentTypeSelector.SelectedItem = assessment.Type;
            StartDateSelector.Date = assessment.StartDate;
            DueDateSelector.Date = assessment.DueDate;
            Alert.IsToggled = assessment.Alert;

        }

        async void DeleteAssessment_Clicked(object sender, EventArgs e)
        {
            bool confirmDel = await DisplayAlert("Confirm?", "Delete Assessment?", "Yes", "No");

            if (confirmDel)
            {
                await DatabaseServices.DeleteAssessment(SelectedAssessmentId);
                await DisplayAlert("Confirmation", "Assessment Deleted", "Ok");
            }
            else
            {
                await DisplayAlert("Confirmation", "Canceled Delete Operation", "Ok");
            }

            await Navigation.PopAsync();
        }

        async void SaveAssessment_Clicked(object sender, EventArgs e)
        {
            var existingAssessments = DatabaseServices.GetAssessments(SelectedCourseId);
            bool typeExists = false;
            if (string.IsNullOrWhiteSpace(AssessmentName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Name", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(AssessmentTypeSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error", "Please Choose A Type", "Ok");
                return;
            }

            if (
                StartDateSelector.Date >= DueDateSelector.Date)
            {
                await DisplayAlert("Error", "Start Date Must Be Before Due Date", "Ok");
                return;
            }

            foreach (Assessment assessment in await existingAssessments)
            {
                if (assessment.ID.ToString() != AssessmentID.Text && assessment.Type == AssessmentTypeSelector.SelectedItem.ToString())
                {
                    typeExists = true;
                }

            }

            if (typeExists)
            {
                await DisplayAlert("Invalid Data", $"Assessment Type {AssessmentTypeSelector.SelectedItem} Exists Already", "Ok");
                return;
            }
            else
            {
                await DatabaseServices.UpdateAssessment(SelectedAssessmentId, AssessmentName.Text, AssessmentTypeSelector.SelectedItem.ToString(),
                                            StartDateSelector.Date, DueDateSelector.Date, Alert.IsToggled);
                await DisplayAlert("Success", "Assessment Successfully Updated!", "Ok");
                await Navigation.PopAsync();
            }
        }

    }
}

