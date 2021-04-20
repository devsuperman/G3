using Garimpo3.ViewModels.Peons;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Peons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeonsPage : ContentPage
    {
        public PeonsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new PeonsViewModel();                
        }
    }
}
