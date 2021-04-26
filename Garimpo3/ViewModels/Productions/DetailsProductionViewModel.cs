using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace Garimpo3.ViewModels.Productions
{
    public class DetailsProductionViewModel : BaseViewModel
    {
        public string Date { get;}
        public decimal Amount { get;}
        public List<CommissionDTO> Commissions { get;} = new List<CommissionDTO>();
        public DetailsProductionViewModel(string id)
        {
            var realm = Realm.GetInstance();
            var production = realm.Find<Production>(new ObjectId(id));
            
            Date = production.DateText;
            Amount = production.Amount;

            foreach (var c in production.Commissions)
            {
                var peon = realm.All<Peon>().FirstOrDefault(a => a.Id == c.PeonId);
                var dtoCommission = new CommissionDTO(peon.Name, c.Value);
                Commissions.Add(dtoCommission);
            }

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
