using Realms;
using System;

namespace Garimpo3.Models
{
    public class Payment : EmbeddedObject
    {        
        public DateTimeOffset Date { get; set; }
        public decimal Value { get; set; }
        public Peon Peon { get; set; }
        public string DateText => this.Date.ToLocalTime().DateTime.ToShortDateString();
    }
}