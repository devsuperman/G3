using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace Garimpo3.ViewModels.Peons
{
    public class DetailsPeonViewModel : BaseViewModel
    {
        public string Name { get;}
        public decimal Balance { get;}
        public bool Active { get;}
        public IList<Commission> Commissions { get;}        

        public DetailsPeonViewModel(string id)
        {
            using var realm = Realm.GetInstance();
            var peon = realm.Find<Peon>(new ObjectId(id));
            
            this.Name = peon.Name;
            this.Balance = peon.Balance;
            this.Active = peon.Active;
            this.Commissions = peon.Commissions.ToList();
        }
    }
}
