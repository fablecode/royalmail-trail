using System;
using System.Threading.Tasks;
using royalmail.trail.ViewModels.Infrastructure.ViewModels;

namespace royalmail.trail.ViewModels.Infrastructure.Services
{
    public interface INavigationService
    {
        Type GetView<TViewModel>();
        Type GetView(Type viewModel);
        Type GetViewModel(Type view);
        Task NavigateTo<T>(Type viewModelType) where T : ViewModelBase;
        Task NavigateTo<T>(Type viewModelType, object param) where T : ViewModelBase;

    }
}