using System;
using System.Threading.Tasks;
using Garimpo3.Models;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using Xamarin.Forms;

namespace Garimpo3.ViewModels.Peons
{
    public class AddPaymentViewModel : BaseViewModel
    {
        DateTime date;
        string vaalue;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }
        public string Vaalue { get => vaalue; set => SetProperty(ref vaalue, value); }
        
        public AsyncCommand SaveCommand { get; }
        public string Id { get; }

        public AddPaymentViewModel(string id)
        {
            Id = id;
            Title = "Pagamentos";
            SaveCommand = new AsyncCommand(Save);
            Date = DateTime.Today;
        }

        async Task Save()
        {
            IsBusy = true;
            var realm = Realm.GetInstance();
            var peon = realm.Find<Peon>(new ObjectId(Id));

            realm.Write(() => peon.AddPayment(Date, decimal.Parse(Vaalue)));            

            await Shell.Current.GoToAsync("..");

            IsBusy = false;
        }
    }
}
