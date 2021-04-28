using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using Realms;
using System.Linq;

namespace Garimpo3.ViewModels.Peons
{
    public class CommissionsViewModel : BaseViewModel
    {
        public IQueryable<Commission> Commissions { get; }
        public CommissionsViewModel(string id)
        {
            var realm = Realm.GetInstance();
            var peonId = new ObjectId(id);
            this.Commissions = realm.All<Commission>().Where(w => w.PeonId == peonId);
        }
    }
}
