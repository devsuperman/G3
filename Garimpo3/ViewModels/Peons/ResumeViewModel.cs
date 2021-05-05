using Garimpo3.Models;
using Garimpo3.Services;
using Garimpo3.Views.Peons;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garimpo3.ViewModels.Peons
{
    public class ResumeViewModel : BaseViewModel
    {
        public string Name { get;}
        public decimal Balance { get;}
        public bool Active { get;}
        public AsyncCommand EditCommand { get; }
        public string Id { get; }

        public ResumeViewModel(string id)
        {
            Id = id;
            EditCommand = new AsyncCommand(Edit);

            IsBusy = true;

            var config = Task.Run(() => MyRealmConfig.GetConfig()).Result;
            var realm = Realm.GetInstance(config);

            var peon = realm.Find<Peon>(new ObjectId(id));
            
            this.Name = peon.Name;
            this.Balance = peon.Balance;
            this.Active = peon.Active;

            IsBusy = false;
        }

        private async Task Edit()
        {
            var route = $"{nameof(EditPeonPage)}?id={Id}";
            await Shell.Current.GoToAsync(route);
        }        
    }
}
