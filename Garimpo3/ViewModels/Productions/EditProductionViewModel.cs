using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Realms;
using Garimpo3.Models;

namespace Garimpo3.ViewModels.Productions
{
    public class EditProductionViewModel : BaseViewModel
    {
        string id;
        DateTimeOffset date;
        public DateTimeOffset Date { get => date; set => SetProperty(ref date, value); }

        string amount;
        public string Amount { get => amount; set => SetProperty(ref amount, value); }
        
        public AsyncCommand SaveCommand { get; }

        public EditProductionViewModel(string id)
        {
            this.id = id;
            Title = "Editar Despescada";
            SaveCommand = new AsyncCommand(Save);
            LoadProduction();
        }
        void LoadProduction()
        {
            IsBusy = true;

            var realm = Realm.GetInstance();
            var production = realm.Find<Production>(id);

            Date = production.Date;
            Amount = production.Amount.ToString();

            IsBusy = false;
        }

        async Task Save()
        {
            IsBusy = true;
            
            var realm = Realm.GetInstance();
            var production = realm.Find<Production>(id);

            realm.Write(() =>
            {
                production.Update(Date, Convert.ToDecimal(Amount));
            });

            realm.Dispose();

            await Xamarin.Forms.Shell.Current.GoToAsync("..");
            
            IsBusy = false;
        }
    }
}
