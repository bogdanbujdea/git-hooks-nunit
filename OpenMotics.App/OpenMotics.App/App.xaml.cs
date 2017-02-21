using OpenMotics.App.Infrastructure;
using OpenMotics.App.Views;
using Xamarin.Forms;

namespace OpenMotics.App
{
    public partial class App
    {
        public App(AppSetup setup)
        {
            InitializeComponent();
            AppContainer.Container = setup.CreateContainer();
            
            MainPage = new NavigationPage(new DevicesView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
