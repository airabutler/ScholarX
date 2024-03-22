using ABC971.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABC971.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTerm: ContentPage
    {
        public AddTerm()
        {
            InitializeComponent();
        }

        async void SaveNewTerm_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Error", "Please Enter A Name", "Ok");
                return;
            }

            if (TermStartSelector.Date >= TermEndSelector.Date)
            {
                await DisplayAlert("Error", "End Date Must Not Precede Start Date", "Ok");
                return;
            }

            if (TermStatusSelector.SelectedItem == null || string.IsNullOrWhiteSpace(TermStatusSelector.SelectedItem.ToString()))
            {
                await DisplayAlert("Error", "Please Choose A Status", "Ok");
                return;
            }


            await DatabaseServices.AddTerm(TermName.Text, TermStatusSelector.SelectedItem.ToString(),
                                           TermStartSelector.Date, TermEndSelector.Date);

            await DisplayAlert("Success", "New Term Added", "Ok");

            await Navigation.PopAsync();
        }
    }
}
