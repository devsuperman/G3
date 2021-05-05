using Garimpo3.Services;
using Garimpo3.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Garimpo3.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public AsyncCommand UpdateRealmCommand { get; }
        public AsyncCommand LogoutCommand { get; }
        public HomeViewModel()
        {
            UpdateRealmCommand = new AsyncCommand(UpdateRealmAsync);
            LogoutCommand = new AsyncCommand(LogoutAsync);
        }

        private async Task LogoutAsync()
        {
            await MyRealmConfig.LogoutAsync();
            await Xamarin.Forms.Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async Task UpdateRealmAsync()
        {
            IsBusy = true;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {   
                var realm = await Realm.GetInstanceAsync(MyRealmConfig.GetConfig());
                realm.Dispose();
            }

            IsBusy = false;
        }
    }
}
