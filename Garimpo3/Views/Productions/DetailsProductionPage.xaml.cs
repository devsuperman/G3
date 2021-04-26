using Garimpo3.Models;
using MongoDB.Bson;
using Realms;
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

            var realm = Realm.GetInstance();
            var production = realm.Find<Production>(new ObjectId(id));
            BindingContext = production;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditProductionPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}