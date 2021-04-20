using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Peons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("id","id")]
    public partial class DetailsPeonPage : ContentPage
    {
        public string id { get; set; }
        public DetailsPeonPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            int.TryParse(id, out var result);
            var peon = await Services.PeonsService.GetAsync(result);

            BindingContext = peon;
        }

        

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditPeonPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}