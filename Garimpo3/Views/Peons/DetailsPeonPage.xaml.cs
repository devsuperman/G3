using Garimpo3.Models;
using MongoDB.Bson;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            using var realm = Realms.Realm.GetInstance();
            var peon = realm.Find<Peon>(new ObjectId(id));

            BindingContext = new Peon(peon.Name, peon.DredgeId);
        }        

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditPeonPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}