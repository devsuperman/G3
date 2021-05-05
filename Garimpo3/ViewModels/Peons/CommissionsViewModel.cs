using Garimpo3.Models;
using Garimpo3.Services;
using MongoDB.Bson;
using MvvmHelpers;
using Realms;
using System.Linq;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Peons
{
    public class CommissionsViewModel : BaseViewModel
    {
        public IQueryable<Commission> Commissions { get; }
        public CommissionsViewModel(string id)
        {
            IsBusy = true;

            var realm = Realm.GetInstance(MyRealmConfig.GetConfig());

            var peonId = new ObjectId(id);
            this.Commissions = realm.All<Commission>().Where(w => w.PeonId == peonId);

            IsBusy = false;
        }
    }
}
