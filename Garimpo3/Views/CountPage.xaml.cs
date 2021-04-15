using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Garimpo3.ViewModels;

namespace Garimpo3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountPage : ContentPage
    {
        public CountPage()
        {
            BindingContext = new CountViewModel();
            InitializeComponent();
        }
    }
}