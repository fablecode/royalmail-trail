using royalmail.trail.Configuration;
using Xamarin.Forms;
using MainPage = royalmail.trail.Views.Main.MainPage;

namespace royalmail.trail
{
    public partial class App : Application
    {
        static App()
        {
            Startup.ConfigureAsync();
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage ( new MainPage());
        }

        #region protected overrides
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
        #endregion
    }
}
