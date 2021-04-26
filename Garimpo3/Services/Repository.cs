using Realms;
using Realms.Sync;
using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public static class Repository
    {
        public static async Task<Realm> GetInstanceAsync()
        {
            var app = Realms.Sync.App.Create("garimpoapp-yoopk");
            var user = await app.LogInAsync(Credentials.EmailPassword("hsbtiago@gmail.com","bahia55"));
            var config = new SyncConfiguration("alcon", user);            
            var realm = await Realm.GetInstanceAsync(config);
            return realm;
        }        
    }
}
