using Garimpo3.Models;
using Garimpo3.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using Realms.Sync;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Garimpo3.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public AsyncCommand UpdateRealmCommand { get; }
        public HomeViewModel()
        {
            UpdateRealmCommand = new AsyncCommand(UpdateRealm);            
        }

        private async Task UpdateRealm()
        {
            IsBusy = true;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var app = Realms.Sync.App.Create(Constants.AppId);
                var user = await app.LogInAsync(Credentials.Anonymous());
                var config = new SyncConfiguration(Constants.Partition, user);
                var realm = await Realm.GetInstanceAsync(config);
                realm.Dispose();
            }

            IsBusy = false;
        }
    }
}
