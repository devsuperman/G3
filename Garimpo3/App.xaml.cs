using Xamarin.Forms;

namespace Garimpo3
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<Services.IPopUp, Services.DisplayAlertService>();
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
