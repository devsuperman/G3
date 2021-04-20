
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Productions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductionsPage : ContentPage
    {
        public ProductionsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ViewModels.Productions.ProductionsViewModel();
        }
    }
}