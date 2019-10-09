using System;
using Reactive.Bindings;
using royalmail.trail.ViewModels.Infrastructure.ViewModels;
using Console = System.Console;

namespace royalmail.trail.ViewModels.BarcodeDetails
{
    public class BarcodeDetailsViewModel : ViewModelBase
    {
        public ReactiveProperty<bool> IsBusy { get; }
        public ReactiveProperty<string> BusyText { get; }
        public ReactiveProperty<string> ReferenceNumber { get; }

        public BarcodeDetailsViewModel()
        {
            IsBusy = new ReactiveProperty<bool>(true);
            BusyText = new ReactiveProperty<string>("loading..");
            ReferenceNumber = new ReactiveProperty<string>();
            ReferenceNumber.Subscribe(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}