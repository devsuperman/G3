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
using Realms;

namespace Garimpo3.ViewModels.Peons
{
    public class PeonsViewModel : BaseViewModel
    {
        public AsyncCommand AddPeonCommand { get; }
        public AsyncCommand<Peon> DetailsPeonCommand { get; }
        public AsyncCommand SyncCommand { get; }
        public ObservableCollection<Peon> Peons { get; } = new ObservableCollection<Peon>();

        public PeonsViewModel()
        {
            Title = "Peões";
            AddPeonCommand = new AsyncCommand(AddPeon);
            DetailsPeonCommand = new AsyncCommand<Peon>(DetailsPeon);
            SyncCommand = new AsyncCommand(Sync);
            LoadPeons();
        }

        private async Task Sync()
        {
            IsBusy = true;
            try
            {
                var realm = await Repository.GetInstanceAsync();

                var items = realm.All<Peon>();

                foreach (var item in items)
                    Peons.Add(item);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task DetailsPeon(Peon peon)
        {
            if (peon is null)
                return;

            var route = $"{nameof(DetailsPeonPage)}?id={peon.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private void LoadPeons()
        {
            IsBusy = true;
            var realm = Realm.GetInstance();

            try
            {
                Peons.Clear();

                var items = realm.All<Peon>();

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
            await Shell.Current.GoToAsync(nameof(NewPeonPage));
        }
    }
}
