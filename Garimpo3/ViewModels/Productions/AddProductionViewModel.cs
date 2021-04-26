using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Garimpo3.Models;
using System.Collections.Generic;
using System.Linq;
using Garimpo3.Services;
using Realms;

namespace Garimpo3.ViewModels.Productions
{
    public class AddProductionViewModel : BaseViewModel
    {
        DateTime date;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

        string amount;
        public string Amount { get => amount; set => SetProperty(ref amount, value); }

        List<Peon> availablePeons;
        public List<Peon> AvailablePeons { get => availablePeons; set => SetProperty(ref availablePeons, value); }


        Peon selectedPeon1;
        public Peon SelectedPeon1 { get => selectedPeon1; set => SetProperty(ref selectedPeon1, value); }

        string percent1;
        public string Percent1 { get => percent1; set => SetProperty(ref percent1, value); }

        string commission1;
        public string Commission1 { get => commission1; set => SetProperty(ref commission1, value); }


        Peon selectedPeon2;
        public Peon SelectedPeon2 { get => selectedPeon2; set => SetProperty(ref selectedPeon2, value); }

        string percent2;
        public string Percent2 { get => percent2; set => SetProperty(ref percent2, value); }

        string commission2;
        public string Commission2 { get => commission2; set => SetProperty(ref commission2, value); }



        Peon selectedPeon3;
        public Peon SelectedPeon3 { get => selectedPeon3; set => SetProperty(ref selectedPeon3, value); }

        string percent3;
        public string Percent3 { get => percent3; set => SetProperty(ref percent3, value); }

        string commission3;
        public string Commission3 { get => commission3; set => SetProperty(ref commission3, value); }




        Peon selectedPeon4;
        public Peon SelectedPeon4 { get => selectedPeon4; set => SetProperty(ref selectedPeon4, value); }

        string percent4;
        public string Percent4 { get => percent4; set => SetProperty(ref percent4, value); }

        string commission4;
        public string Commission4 { get => commission4; set => SetProperty(ref commission4, value); }



        Peon selectedPeon5;
        public Peon SelectedPeon5 { get => selectedPeon5; set => SetProperty(ref selectedPeon5, value); }

        string percent5;
        public string Percent5 { get => percent5; set => SetProperty(ref percent5, value); }

        string commission5;
        public string Commission5 { get => commission5; set => SetProperty(ref commission5, value); }




        Peon selectedPeon6;
        public Peon SelectedPeon6 { get => selectedPeon6; set => SetProperty(ref selectedPeon6, value); }

        string percent6;
        public string Percent6 { get => percent6; set => SetProperty(ref percent6, value); }

        string commission6;
        public string Commission6 { get => commission6; set => SetProperty(ref commission6, value); }


        public AsyncCommand SaveCommand { get; }
        public Command UpdateCommissionCommand { get; }

        public AddProductionViewModel()
        {
            Date = DateTime.Today;
            Title = "Nova Despescada";
            SaveCommand = new AsyncCommand(Save);
            UpdateCommissionCommand = new Command<string>(UpdateCommission);
            LoadPeons();
        }        

        private void UpdateCommission(string row)
        {
            int.TryParse(row, out var result);

            var percent = this.GetType().GetProperty("Percent" + row).GetValue(this, null).ToString();

            decimal.TryParse(percent, out var percentValue);
            decimal.TryParse(Amount, out var amountValue);

            var newCommission = (amountValue * (percentValue / 100)).ToString("N2");

            this.GetType().GetProperty("Commission" + row).SetValue(this, newCommission);
        }

        private List<Commission> GetCommission()
        {
            var numbersOfRows = 6;
            var commissions = new List<Commission>();

            for (int i = 1; i <= numbersOfRows; i++)
            {
                var peon = (Peon)this.GetType().GetProperty("SelectedPeon" + i).GetValue(this, null);
                var commission = this.GetType().GetProperty("Commission" + i).GetValue(this, null)?.ToString();

                var validCommission = peon != null && !string.IsNullOrEmpty(peon.DredgeId) && !string.IsNullOrEmpty(commission);

                if (validCommission)
                    commissions.Add(new Commission(peon, decimal.Parse(commission)));
            }

            return commissions;
        }

        private void LoadPeons()
        {
            AvailablePeons = new List<Peon>();

            var voidPeon = new Peon("Ninguém", "");
            AvailablePeons.Add(voidPeon);

            var realm = Realm.GetInstance();
            var peons = realm.All<Peon>().Where(w => w.Active).OrderBy(a => a.Name);

            AvailablePeons.AddRange(peons);
        }

        async Task Save()
        {
            var realm = Realm.GetInstance();
            var commissions = GetCommission();
            
            var production = new Production(Date, Convert.ToDecimal(Amount));

            foreach (var c in commissions)
                production.Commissions.Add(c);

            var peonsIds = commissions.Select(s => s.PeonId).ToList();
            var peons = realm.All<Peon>().ToList().Where(w => peonsIds.Contains(w.Id)).ToList();

            realm.Write(() =>
            {
                realm.Add(production);

                foreach (var c in commissions)
                {
                    var peon = peons.FirstOrDefault(f => f.Id == c.PeonId);
                    peon.AddCommission(c.Value);
                }
            });

            await Xamarin.Forms.Shell.Current.GoToAsync("..");
        }
    }
}
