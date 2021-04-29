using Garimpo3.ViewModels.Payments;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Payments
{
    [QueryProperty("id", "id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPaymentPage : ContentPage
    {
        public string id { get; set; }
        public AddPaymentPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AddPaymentViewModel(id);
        }
    }
}