using Realms.Sync;
using Garimpo3.Models;
using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public static class MyRealmConfig
    {
        static SyncConfiguration syncConfig;
        public static SyncConfiguration Get()
        {
            if (syncConfig is null)
            {
                var app = Realms.Sync.App.Create(Constants.AppId);
                var user = Task.Run(() => app.LogInAsync(Credentials.Anonymous())).Result;
                syncConfig = new SyncConfiguration(Constants.Partition, user);
            }

            return syncConfig;
        }
    }
}
