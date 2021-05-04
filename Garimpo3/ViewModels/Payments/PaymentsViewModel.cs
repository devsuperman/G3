using Garimpo3.Models;
using Garimpo3.Services;
using Garimpo3.Views.Payments;
using Garimpo3.Views.Peons;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garimpo3.ViewModels.Payments
{
    public class PaymentsViewModel : BaseViewModel
    {
        readonly Services.IPopUp _popUp;
        Payment selectedPayment;
        public Payment SelectedPayment { get => selectedPayment; set => SetProperty(ref selectedPayment, value); }
        public IList<Payment> Payments { get; }
        public AsyncCommand AddPaymentCommand { get; }
        public AsyncCommand PaymentTappedCommand { get; }
        public string Id { get; }
        Realm realm;

        public PaymentsViewModel(string id)
        {
            IsBusy = true;
            var peonId = new ObjectId(id);
            realm = Realm.GetInstance(MyRealmConfig.Get());
            this.Payments = realm.Find<Peon>(peonId).Payments;
            AddPaymentCommand = new AsyncCommand(AddPayment);
            PaymentTappedCommand = new AsyncCommand(PaymentTapped);
            Id = id;
            this._popUp = DependencyService.Get<IPopUp>();
            IsBusy = false;
        }

        private async Task PaymentTapped()
        {
            var action = await _popUp.ActionSheet("Opções", "Voltar", null, "Excluir Pagamento");

            if (!action.Contains("Excluir"))
                return;

            var confirm = await _popUp.Confirm($"Tem certeza que deseja excluir  o pagamento de {SelectedPayment.Value:N2}g?", "Sim", "Não! Cancela!");

            if (!confirm)
                return;

            await DeletePayment();
        }

        private async Task DeletePayment()
        {
            var peon = realm.Find<Peon>(new ObjectId(Id));
            
            realm.Write(() => peon.RemovePayment(SelectedPayment));

            var route = $"{nameof(DetailsPeonPage)}?id={peon.Id}";
            await Shell.Current.GoToAsync(route);

            realm.Dispose();
        }

        private async Task AddPayment()
        {
            var route = $"{nameof(AddPaymentPage)}?id={Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
