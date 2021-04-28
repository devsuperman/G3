using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using Realms;
using System.Collections.Generic;

namespace Garimpo3.ViewModels.Peons
{
    public class PaymentsViewModel : BaseViewModel
    {
        public IList<Payment> Payments { get; }
        public PaymentsViewModel(string id)
        {
            var peonId = new ObjectId(id);
            var realm = Realm.GetInstance();
            this.Payments = realm.Find<Peon>(peonId).Payments;
        }
    }
}
