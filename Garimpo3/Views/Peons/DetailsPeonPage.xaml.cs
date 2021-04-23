using Garimpo3.Models;
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
            var db = Realms.Realm.GetInstance();
            BindingContext = db.Find<Peon>(id);
        }        

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var route = $"{nameof(EditPeonPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}