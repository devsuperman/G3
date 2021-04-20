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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            int.TryParse(id, out var result);

            BindingContext = await Services.ProductionsService.GetAsync(result);
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditProductionPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}