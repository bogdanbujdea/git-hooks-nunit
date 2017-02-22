using OpenMotics.App.Infrastructure;

namespace OpenMotics.App.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new OpenMotics.App.App(new AppSetup()));
        }
    }
}
