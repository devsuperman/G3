using Garimpo3.Models;
using Garimpo3.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Peons
{
    public class AddPeonViewModel : BaseViewModel
    {
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public AsyncCommand SaveCommand { get; }

        public AddPeonViewModel()
        {
            Title = "Novo Peão";
            SaveCommand = new AsyncCommand(Save);
        }

        async Task Save()
        {
            var peon = new Peon(Name);

            var db = Realms.Realm.GetInstance();

            db.Write(() => { 
                db.Add(peon);
            });
            
            await Xamarin.Forms.Shell.Current.GoToAsync("..");
        }
    }
}
