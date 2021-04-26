﻿using Garimpo3.Models;
using Garimpo3.Services;
using MongoDB.Bson;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace Garimpo3.ViewModels.Peons
{
    public class EditPeonViewModel : BaseViewModel
    {
        string id;
        
        string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        bool active;
        public bool Active { get => active; set => SetProperty(ref active, value); }

        public AsyncCommand SaveCommand { get; }

        public EditPeonViewModel(string id)
        {
            this.id = id;
            Title = "Editar Peão";
            SaveCommand = new AsyncCommand(Save);
            LoadPeon();
        }
        void LoadPeon()
        {
            IsBusy = true;
            using var realm = Realms.Realm.GetInstance();
            var peon = realm.Find<Peon>(new ObjectId(id));

            Name = peon.Name;
            Active = peon.Active;

            IsBusy = false;
        }

        async Task Save()
        {
            IsBusy = true;

            using var realm = Realms.Realm.GetInstance();
            var peon = realm.Find<Peon>(new ObjectId(id));

            realm.Write(() =>
            {
                peon.Update(Name, Active);                
            });

            await Xamarin.Forms.Shell.Current.GoToAsync("..");
            
            IsBusy = false;
        }
    }
}
