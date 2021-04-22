using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Garimpo3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garimpo3.ViewModels.Productions
{
    public class AddProductionViewModel : BaseViewModel
    {
        DateTime date;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

        string amount;
        public string Amount { get => amount; set => SetProperty(ref amount, value); }

        IList<Peon> availablePeons;
        public IList<Peon> AvailablePeons { get => availablePeons; set => SetProperty(ref availablePeons, value); }

        IList<Peon> allPeons;
        public IList<Peon> AllPeons { get => allPeons; set => SetProperty(ref allPeons, value); }

        Peon selectedPeon;
        public Peon SelectedPeon { get => selectedPeon; set => SetProperty(ref selectedPeon, value); }
                
        string percent1;
        public string Percent1 { get => percent1; set => SetProperty(ref percent1, value); }
        
        string commission1;
        public string Commission1 { get => commission1; set => SetProperty(ref commission1, value); }

        string percent2;
        public string Percent2 { get => percent2; set => SetProperty(ref percent2, value); }

        string commission2;
        public string Commission2 { get => commission2; set => SetProperty(ref commission2, value); }

        public AsyncCommand SaveCommand { get; }
        public Command UpdateCommissionCommand { get; }
        public Command UpdatePeonsCommand { get; }

        public AddProductionViewModel()
        {
            Date = DateTime.Today;
            Title = "Nova Despescada";
            SaveCommand = new AsyncCommand(Save);
            UpdateCommissionCommand = new Command<string>(UpdateCommission);
            UpdatePeonsCommand = new Command<string>(UpdatePeons);
            LoadPeons();
        }

        private void UpdatePeons(string row)
        {
            //TODO

            // Various properties of PeonSelected

            //On change selected peon, check de list of peons properties and update the list of available peons

            //if (SelectedPeon != null)
            //    AvailablePeons.Remove(SelectedPeon);
        }

        private void UpdateCommission(string row)
        {
            int.TryParse(row, out var result);

            var percent = this.GetType().GetProperty("Percent" + row).GetValue(this, null).ToString();

            decimal.TryParse(percent, out var percentValue);
            decimal.TryParse(Amount, out var amountValue);

            var newCommission = (amountValue * (percentValue/100)).ToString("N2");

            this.GetType().GetProperty("Commission" + row).SetValue(this, newCommission);
        }

        private void LoadPeons()
        {
            AllPeons = Task.Run(() => Services.PeonsService.GetAllAsync()).Result.ToList();
            AvailablePeons = AllPeons;
        }

        async Task Save()
        {
            await Services.ProductionsService.AddAsync(Date, Convert.ToDecimal(Amount));
            await Xamarin.Forms.Shell.Current.GoToAsync("..");
        }
    }
}
