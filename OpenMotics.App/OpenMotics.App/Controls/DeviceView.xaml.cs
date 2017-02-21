using OpenMotics.App.ViewModels;
using ReactiveUI;
using Xamarin.Forms;

namespace OpenMotics.App.Controls
{
    public partial class DeviceView: IViewFor<DeviceControlViewModel>
    {
        public DeviceView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            ViewModel = BindingContext as DeviceControlViewModel;
            this.Bind(ViewModel, vm => vm.IsOn, v => v.SwitchControl.IsToggled);
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.SwitchName.Text);
            this.Bind(ViewModel, vm => vm.ReadableTime, v => v.UpdatedTime.Text);
            this.BindCommand(ViewModel, vm => vm.RefreshDeviceCommand, v => v.RefreshButton);
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(DeviceControlViewModel), typeof(DeviceView));

        public DeviceControlViewModel ViewModel
        {
            get { return (DeviceControlViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (DeviceControlViewModel)value; }
        }
    }
}
