using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garimpo3.ViewModels.Productions
{
    public class DetailsProductionViewModel : BaseViewModel
    {
        Realm realm { get; }
        private readonly Services.IPopUp _popUp;
        string productionId;
        public string Date { get; }
        public decimal Amount { get; }
        public List<CommissionDTO> Commissions { get; } = new List<CommissionDTO>();
        public AsyncCommand DeleteCommand { get; }
        public DetailsProductionViewModel(string productionId)
        {
            this.productionId = productionId;
            this._popUp = DependencyService.Get<Services.IPopUp>();

            DeleteCommand = new AsyncCommand(Delete);

            realm = Realm.GetInstance();
            var production = realm.Find<Production>(new ObjectId(productionId));

            Date = production.DateText;
            Amount = production.Amount;

            foreach (var c in production.Commissions)
            {
                var peon = realm.All<Peon>().FirstOrDefault(a => a.Id == c.PeonId);
                var dtoCommission = new CommissionDTO(peon?.Name, c.Value);
                Commissions.Add(dtoCommission);
            }

        }

        private async Task Delete()
        {
            IsBusy = true;
            var confirm = await _popUp.Confirm("Tem certeza que deseja excluir essa Despescada?", "Sim!", "Não! Deixa quieto!");

            if (!confirm)
                return;

            var production = realm.Find<Production>(new ObjectId(productionId));

            realm.Write(() => realm.Remove(production));

            await Shell.Current.GoToAsync("..");

            IsBusy = false;
        }
    }

    public class CommissionDTO
    {
        public CommissionDTO(string name, decimal value)
        {
            Description = $"{value:N2} - {name}";
        }

        public string Description { get; }
    }
}
