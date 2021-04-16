using Garimpo3.Models;
using Garimpo3.Services;
using System;
using MvvmHelpers;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Garimpo3.Views.Peons;
using MvvmHelpers.Commands;

namespace Garimpo3.ViewModels.Peons
{
    public class PeonsViewModel : BaseViewModel
    {
        public AsyncCommand AddPeonCommand { get; }
        public AsyncCommand<Peon> DetailsPeonCommand { get; }
        public ObservableCollection<Peon> Peons { get;} = new ObservableCollection<Peon>();

        public PeonsViewModel()
        {
            Title = "Peões";
            AddPeonCommand = new AsyncCommand(AddPeon);
            DetailsPeonCommand = new AsyncCommand<Peon>(DetailsPeon);
            LoadPeons();
        }

        async Task DetailsPeon(Peon peon)
        {
            if (peon is null)
                return;

            var route = $"{nameof(DetailsPeonPage)}?Id={peon.Id}";
            await Shell.Current.GoToAsync(route);
        }

        void LoadPeons()
        {
            IsBusy = true;

            try
            {
                Peons.Clear();
                var items = Task.Run(() => PeonsService.GetAllAsync()).Result;
                
                foreach (var item in items)
                    Peons.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddPeon()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync(nameof(NewPeonPage));
        }        
    }
}
