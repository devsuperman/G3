using Garimpo3.ViewModels.Productions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Productions
{
    [QueryProperty("id", "id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsProductionPage : ContentPage
    {
        public string id { get; set; }
        public DetailsProductionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new DetailsProductionViewModel(id);
        }        
    }
}