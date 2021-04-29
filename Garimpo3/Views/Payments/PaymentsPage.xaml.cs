using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garimpo3.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public PaymentsPage()
        {
            InitializeComponent();
        }
    }
}
