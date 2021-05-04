using System;
using Realms;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Garimpo3.Models
{
    public class Production : RealmObject
    {
        public Production()
        {

        }
        public Production(DateTimeOffset date, decimal amount, string dredgeId)
        {
            Date = date;
            Amount = amount;
            DredgeId = dredgeId;
        }

        [PrimaryKey, MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public DateTimeOffset Date { get; set; }
        public string DateText => this.Date.ToLocalTime().DateTime.ToShortDateString();
        public decimal Amount { get; set; }
        public IList<Commission> Commissions { get; }
        [Required]
        public string DredgeId { get; set; }

        internal void Update(DateTimeOffset date, decimal amount)
        {
            this.Date = date;
            this.Amount = amount;
        }

        internal void AddCommission(Commission c)
        {
            c.DredgeId = this.DredgeId;
            c.Peon.Balance += c.Value;
            this.Commissions.Add(c);
        }
    }
}
