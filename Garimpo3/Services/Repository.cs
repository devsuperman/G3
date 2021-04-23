using Realms;
using Realms.Sync;
using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public class Repository
    {   
        public async Task Sync()
        {
            var app = Realms.Sync.App.Create("garimpo3-hhusy");
            var user = await app.LogInAsync(Credentials.Anonymous());
            var config = new SyncConfiguration("Peons", user);
            var db = await Realm.GetInstanceAsync(config);
        }      

    }
}
