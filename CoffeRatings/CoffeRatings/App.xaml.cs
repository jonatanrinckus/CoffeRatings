using CoffeRatings.Services;
using Xamarin.Forms;

namespace CoffeRatings
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var data = new DataAccess();

            MainPage = new CoffeRatings.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
