using System;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Productions
{
    public class AddProductionViewModel : BaseViewModel
    {
        DateTime date;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

        string amount;
        public string Amount { get => amount; set => SetProperty(ref amount, value); }

        public AsyncCommand SaveCommand { get; }

        public AddProductionViewModel()
        {
            Date = DateTime.Today;
            Title = "Nova Despescada";
            SaveCommand = new AsyncCommand(Save);
        }

        async Task Save()
        {
            await Services.ProductionsService.AddAsync(Date, Convert.ToDecimal(Amount));
            await Xamarin.Forms.Shell.Current.GoToAsync("..");
        }
    }
}
