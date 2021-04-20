using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Garimpo3.ViewModels.Productions;

namespace Garimpo3.Views.Productions
{
    [QueryProperty("id","id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProductionPage : ContentPage
    {
        public string id { get; set; }
        public EditProductionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            int.TryParse(id, out var result);
            BindingContext = new EditProductionViewModel(result);
        }
    }
}