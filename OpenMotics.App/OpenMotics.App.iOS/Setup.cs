using Autofac;
using OpenMotics.App.Infrastructure;

namespace OpenMotics.App.iOS
{
    public class Setup: AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);
        }
    }
}
