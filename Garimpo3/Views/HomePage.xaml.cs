using Garimpo3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}