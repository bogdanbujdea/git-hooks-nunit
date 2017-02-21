using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenMotics.SDK.Services
{
    public interface IDeviceManager
    {
        Task<List<Device>> RetrieveDevices();
    }

    public class Device
    {
        public Device()
        {
            UpdatedAt = DateTime.Now;
        }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}