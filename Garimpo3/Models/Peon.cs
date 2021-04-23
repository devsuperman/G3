﻿using MongoDB.Bson;
using Realms;

namespace Garimpo3.Models
{
    public class Peon : RealmObject
    {
        public Peon()
        {

        }
        public Peon(string name)
        {
            Name = name;
        }

        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public decimal Saldo { get; set; } = 0;

        internal void Update(string name, bool active)
        {
            this.Name = name;
            this.Active = active;
        }
    }
}
