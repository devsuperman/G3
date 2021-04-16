using Garimpo3.Views;
using Garimpo3.Views.Peons;
using Xamarin.Forms;

namespace Garimpo3
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewPeonPage), typeof(NewPeonPage));
        }

    }
}
