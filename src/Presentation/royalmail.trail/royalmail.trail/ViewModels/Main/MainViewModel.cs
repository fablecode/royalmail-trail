using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using royalmail.trail.ViewModels.Infrastructure.ViewModels;

namespace royalmail.trail.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "The Reference is required.")]
        public ReactiveProperty<string> ReferenceNumber { get; }
        public ReactiveProperty<string> ReferenceNumberErrorMessage { get; set; }
        public ReactiveProperty<bool> ReferenceNumberFormHasErrors { get; }
        public ReactiveProperty<bool> IsBusy { get; }
        public ReactiveProperty<string> BusyText { get; }
        public ReactiveProperty<bool> FormHasErrors { get; }


        public ReactiveCommand ReferenceNumberUnfocusedCommand { get; }
        public ReactiveCommand SearchCommand { get; }

        public MainViewModel()
        {
            ReferenceNumber = new ReactiveProperty<string>(mode: ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError)
                .SetValidateAttribute(() => ReferenceNumber);

            ReferenceNumberErrorMessage = ReferenceNumber.ObserveErrorChanged
                .Select(x => x?.OfType<string>().FirstOrDefault())
                .ToReactiveProperty();

            ReferenceNumberFormHasErrors = new[]
                {
                    ReferenceNumber.ObserveHasErrors,
                }
                .CombineLatest(x => x.Any(y => y))
                .ToReactiveProperty();

            IsBusy = new ReactiveProperty<bool>(false);
            BusyText = new ReactiveProperty<string>("loading..");


            // You can combine some ObserveHasErrors values.
            FormHasErrors = new[]
                {
                    ReferenceNumber.ObserveHasErrors,
                }
                .CombineLatest(x => !x.Any(y => y))
                .ToReactiveProperty();

            SearchCommand = new[]
                {
                    ReferenceNumber.ObserveHasErrors,
                }
                .CombineLatestValuesAreAllFalse()
                .ToReactiveCommand()
                .WithSubscribe(async () =>
                {
                    IsBusy.Value = true;

                    await Task.Delay(TimeSpan.FromSeconds(5));

                    IsBusy.Value = false;

                });

            ReferenceNumberUnfocusedCommand = new ReactiveCommand();
            ReferenceNumberUnfocusedCommand.Subscribe(_ => ReferenceNumber.ForceValidate());
        }
    }
}