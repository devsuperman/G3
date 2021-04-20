using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Productions
{
    public class EditProductionViewModel : BaseViewModel
    {
        int id;
        DateTime date;
        string amount;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }
        public string Amount { get => amount; set => SetProperty(ref amount, value); }
        
        public AsyncCommand SaveCommand { get; }

        public EditProductionViewModel(int id)
        {
            this.id = id;
            Title = "Editar Despescada";
            SaveCommand = new AsyncCommand(Save);
            LoadProduction();
        }
        void LoadProduction()
        {
            IsBusy = true;
            var production = Task.Run(() => Services.ProductionsService.GetAsync(id)).Result;

            Date = production.Date;
            Amount = production.Amount.ToString();

            IsBusy = false;
        }

        async Task Save()
        {
            IsBusy = true;
            var production = await Services.ProductionsService.GetAsync(id);
            
            production.Update(Date, Convert.ToDecimal(Amount));

            await Services.ProductionsService.UpdateAsync(production);
            await Xamarin.Forms.Shell.Current.GoToAsync("..");
            
            IsBusy = false;
        }
    }
}
