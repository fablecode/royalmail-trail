using royalmail.trail.application;
using royalmail.trail.Services;
using royalmail.trail.ViewModels.BarcodeDetails;
using royalmail.trail.ViewModels.Infrastructure.Services;
using royalmail.trail.ViewModels.Main;
using royalmail.trail.Views.BarcodeDetails;
using royalmail.trail.Views.Main;

namespace royalmail.trail.Configuration
{
    public static class Startup
    {
        public static void ConfigureAsync()
        {
            ConfigureNavigation();
            ConfigureServices();

            ServiceLocator.ServiceCollection.AddApplicationServices();

            ServiceLocator.BuildContainer(); 
        }

        private static void ConfigureServices()
        {
            ServiceLocator.RegisterType<INavigationService, NavigationService>();
        }

        private static void ConfigureNavigation()
        {
            NavigationService.Register<MainViewModel, MainPage>();
            NavigationService.Register<BarcodeDetailsViewModel, BarcodeDetailsPage>();
        }
    }
}