using ABC971.Views;
using Xamarin.Forms;

namespace ABC971
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var homePage = new Homepage();
            var navPage = new NavigationPage(homePage);
            MainPage = navPage;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

