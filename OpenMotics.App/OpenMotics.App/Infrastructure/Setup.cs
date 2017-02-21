using Autofac;
using OpenMotics.SDK.Services;

namespace OpenMotics.App.Infrastructure
{
    public class Setup: AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);

            cb.RegisterType<DeviceManager>().As<IDeviceManager>();
        }
    }
}
