
using Garimpo3.ViewModels.Peons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Peons
{
    [QueryProperty("id","id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPeonPage : TabbedPage
    {
        public string id { get; set; }
        public DetailsPeonPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            resumePage.BindingContext = new ResumeViewModel(id);
            commissionPage.BindingContext = new CommissionsViewModel(id);
        }
    }
}