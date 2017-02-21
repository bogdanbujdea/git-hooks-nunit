using System.Threading.Tasks;
using Autofac;
using OpenMotics.App.Infrastructure;
using OpenMotics.SDK.Services;
using ReactiveUI;

namespace OpenMotics.App.ViewModels
{
    public class DevicesViewModel : ViewModelBase
    {
        private readonly IDeviceManager _deviceManager;
        private ReactiveList<DeviceControlViewModel> _devices;

        public ReactiveList<DeviceControlViewModel> Devices
        {
            get { return _devices; }
            set { this.RaiseAndSetIfChanged(ref _devices, value); }
        }

        public DevicesViewModel(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
            RefreshDevicesCommand = ReactiveCommand.CreateFromTask(RefreshDevices);
            RefreshDevicesCommand.IsExecuting.ToProperty(this, x => x.IsLoading, out _isLoading);
            Devices = new ReactiveList<DeviceControlViewModel>();
        }

        private async Task RefreshDevices()
        {
            var deviceList = await _deviceManager.RetrieveDevices();
            foreach (var device in deviceList)
            {
                var deviceControlViewModel = AppContainer.Container.Resolve<DeviceControlViewModel>();
                deviceControlViewModel.Name = device.Name;
                deviceControlViewModel.IsOn = device.IsOn;
                deviceControlViewModel.ReadableTime = device.UpdatedAt.ToString("M");
                Devices.Add(deviceControlViewModel);
            }
        }


        

        public ReactiveCommand RefreshDevicesCommand { get; set; }
    }
}

