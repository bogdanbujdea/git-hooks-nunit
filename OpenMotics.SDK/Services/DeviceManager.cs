using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenMotics.SDK.Services
{
    public class DeviceManager: IDeviceManager
    {
        public async Task<List<Device>> RetrieveDevices()
        {
            await Task.Delay(1500);
            return new List<Device>
            {
                new Device
                {
                    IsOn = true,
                    Name = "Kitchen"
                },
                new Device
                {
                    Name = "Bedroom",
                    UpdatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                }
            };
        }
    }
}