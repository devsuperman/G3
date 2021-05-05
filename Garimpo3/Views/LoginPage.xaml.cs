using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Garimpo3.ViewModels;

namespace Garimpo3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
        
    }
}