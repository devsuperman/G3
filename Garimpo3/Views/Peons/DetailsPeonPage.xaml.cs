using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Peons
{
    [QueryProperty("id","id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
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

            BindingContext = await Services.PeonsService.GetAsync(result); ;
        }        

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditPeonPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}