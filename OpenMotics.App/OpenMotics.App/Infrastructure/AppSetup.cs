using Autofac;
using OpenMotics.App.ViewModels;
using OpenMotics.SDK.Services;

namespace OpenMotics.App.Infrastructure
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<DeviceManager>().As<IDeviceManager>();

            cb.RegisterType<DevicesViewModel>().SingleInstance();
            cb.RegisterType<DeviceControlViewModel>().AsSelf();
        }
    }
}