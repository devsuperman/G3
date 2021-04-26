using Garimpo3.Models;
using Garimpo3.Services;
using System;
using MvvmHelpers;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MvvmHelpers.Commands;
using Garimpo3.Views.Productions;
using Realms;

namespace Garimpo3.ViewModels.Productions
{
    public class ProductionsViewModel : BaseViewModel
    {
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Production> DetailsCommand { get; }
        public ObservableCollection<Production> Productions { get;} = new ObservableCollection<Production>();

        public ProductionsViewModel()
        {
            Title = "Despescadas";
            AddCommand = new AsyncCommand(Add);
            DetailsCommand = new AsyncCommand<Production>(Details);
            LoadProductions();
        }

        async Task Details(Production production)
        {
            if (production is null)
                return;

            var route = $"{nameof(DetailsProductionPage)}?id={production.Id}";
            await Shell.Current.GoToAsync(route);
        }

        void LoadProductions()
        {
            IsBusy = true;

            try
            {
                Productions.Clear();
                var realm = Realm.GetInstance();

                var items = realm.All<Production>();
                
                foreach (var item in items)
                    Productions.Add(item);
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

        async Task Add()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync(nameof(NewProductionPage));
        }        
    }
}
