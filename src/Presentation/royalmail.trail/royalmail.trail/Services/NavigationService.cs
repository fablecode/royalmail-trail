using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using royalmail.trail.Contexts;
using royalmail.trail.ViewModels.Infrastructure.Services;
using royalmail.trail.ViewModels.Infrastructure.ViewModels;
using Xamarin.Forms;

namespace royalmail.trail.Services
{
    public class NavigationService : INavigationService
    {
        private static readonly ConcurrentDictionary<Type, Type> ViewModelMap = new ConcurrentDictionary<Type, Type>();

        public static void Register<TViewModel, TView>() where TView : Page
        {
            if (!ViewModelMap.TryAdd(typeof(TViewModel), typeof(TView)))
            {
                throw new InvalidOperationException($"ViewModel already registered '{typeof(TViewModel).FullName}'");
            }
        }

        public Type GetView<TViewModel>()
        {
            return GetView(typeof(TViewModel));
        }
        public Type GetView(Type viewModel)
        {
            if (ViewModelMap.TryGetValue(viewModel, out Type view))
            {
                return view;
            }
            throw new InvalidOperationException($"View not registered for ViewModel '{viewModel.FullName}'");
        }

        public Type GetViewModel(Type view)
        {
            var type = ViewModelMap.Where(r => r.Value == view).Select(r => r.Key).FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException($"View not registered for ViewModel '{view.FullName}'");
            }
            return type;
        }

        public Task NavigateTo<T>(Type viewModelType) where T : ViewModelBase
        {
            return InternalNavigateToAsync(viewModelType, null);
        }
        public Task NavigateTo<T>(Type viewModelType, object param) where T : ViewModelBase
        {
            return InternalNavigateToAsync(viewModelType, param);
        }

        private Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var currentPage = ((NavigationPage)Application.Current.MainPage).CurrentPage;
            var newPage = Activator.CreateInstance(GetView(viewModelType)) as ContentPage;

            if (currentPage != null)
            {
                NavigationContext.SetParam(newPage, parameter);
                return currentPage.Navigation.PushAsync(newPage);
            }

            throw new Exception("Current page not found.");
        }

    }
}