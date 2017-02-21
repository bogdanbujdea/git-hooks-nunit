using System;
using System.Reactive.Linq;
using Autofac;
using OpenMotics.App.Infrastructure;
using OpenMotics.App.ViewModels;
using ReactiveUI;
using Xamarin.Forms;

namespace OpenMotics.App.Views
{
    public partial class DevicesView : IViewFor<DevicesViewModel>
    {
        public DevicesView()
        {
            InitializeComponent();
            ViewModel = AppContainer.Container.Resolve<DevicesViewModel>();
            this.BindCommand(ViewModel, vm => vm.RefreshDevicesCommand, v => v.Refresh);
            this.OneWayBind(ViewModel, x => x.Devices, x => x.DeviceList.ItemsSource);
            this.WhenAnyValue(x => x.ViewModel.IsLoading)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(busy =>
                {
                    Refresh.IsEnabled = !busy;
                    if (busy)
                        Refresh.Text = "Loading...";
                    else Refresh.Text = "Refresh devices";
                });
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(DevicesViewModel), typeof(DevicesView));

        public DevicesViewModel ViewModel
        {
            get { return (DevicesViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (DevicesViewModel)value; }
        }
    }
}