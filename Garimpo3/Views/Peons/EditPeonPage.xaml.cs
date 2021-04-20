using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Garimpo3.ViewModels.Peons;

namespace Garimpo3.Views.Peons
{
    [QueryProperty("id", "id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPeonPage : ContentPage
    {
        public string id { get; set; }
        public EditPeonPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            int.TryParse(id, out var result);
            BindingContext = new EditPeonViewModel(result);
        }
    }
}