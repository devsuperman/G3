using Garimpo3.Views.Productions;
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
            Routing.RegisterRoute(nameof(DetailsPeonPage), typeof(DetailsPeonPage));
            Routing.RegisterRoute(nameof(EditPeonPage), typeof(EditPeonPage));

            Routing.RegisterRoute(nameof(AddPaymentPage), typeof(AddPaymentPage));

            Routing.RegisterRoute(nameof(NewProductionPage), typeof(NewProductionPage));
            Routing.RegisterRoute(nameof(DetailsProductionPage), typeof(DetailsProductionPage));
        }

    }
}
