using MongoDB.Bson;
using Realms;
using System;

namespace Garimpo3.Models
{
    public class Commission : RealmObject
    {
        public Commission()
        {

        }
        public Commission(Peon peon, decimal commission, DateTime date)
        {
            this.Peon = peon;
            this.Date = date;
            this.Value = commission;
        }

        [MapTo("_id"), PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public Peon Peon { get; set; }
        public DateTimeOffset Date { get; set; }
        public string DateText => this.Date.ToLocalTime().DateTime.ToShortDateString();
        public decimal Value { get; set; }
    }
}