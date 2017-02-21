using ReactiveUI;

namespace OpenMotics.App.ViewModels
{
    public class DeviceControlViewModel: ViewModelBase
    {
        private string _name;
        private bool _isOn;
        private string _readableTime;

        public DeviceControlViewModel()
        {
            RefreshDeviceCommand = ReactiveCommand.Create(RefreshDevice);
        }

        public void RefreshDevice()
        {
            IsOn = !IsOn;
        }

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }

        public bool IsOn
        {
            get { return _isOn; }
            set { this.RaiseAndSetIfChanged(ref _isOn, value); }
        }

        public string ReadableTime
        {
            get { return _readableTime; }
            set { this.RaiseAndSetIfChanged(ref _readableTime, value); }
        }

        public ReactiveCommand RefreshDeviceCommand { get; set; }
    }
}
