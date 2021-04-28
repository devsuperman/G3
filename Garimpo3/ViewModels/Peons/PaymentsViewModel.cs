using Garimpo3.Models;
using Garimpo3.Views.Peons;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garimpo3.ViewModels.Peons
{
    public class PaymentsViewModel : BaseViewModel
    {
        public IList<Payment> Payments { get; }
        public AsyncCommand AddPaymentCommand { get; }
        public string Id { get; }

        public PaymentsViewModel(string id)
        {
            var peonId = new ObjectId(id);
            var realm = Realm.GetInstance();
            this.Payments = realm.Find<Peon>(peonId).Payments;
            AddPaymentCommand = new AsyncCommand(AddPayment);
            Id = id;
        }

        private async Task AddPayment()
        {
            var route = $"{nameof(AddPaymentPage)}?id={Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
