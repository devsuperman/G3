using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Peons
{
    public class EditPeonViewModel : BaseViewModel
    {
        int id;
        
        string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        bool active;
        public bool Active { get => active; set => SetProperty(ref active, value); }

        public AsyncCommand SaveCommand { get; }

        public EditPeonViewModel(int id)
        {
            this.id = id;
            Title = "Editar Peão";
            SaveCommand = new AsyncCommand(Save);
            LoadPeon();
        }
        void LoadPeon()
        {
            IsBusy = true;
            var peon = Task.Run(() => Services.PeonsService.GetAsync(id)).Result;

            Name = peon.Name;
            Active = peon.Active;

            IsBusy = false;
        }

        async Task Save()
        {
            IsBusy = true;
            var peon = await Services.PeonsService.GetAsync(id);
            
            peon.Update(Name, Active);

            await Services.PeonsService.UpdateAsync(peon);
            await Xamarin.Forms.Shell.Current.GoToAsync("..");
            
            IsBusy = false;
        }
    }
}
