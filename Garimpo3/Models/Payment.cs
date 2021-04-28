using Realms;
using System;

namespace Garimpo3.Models
{
    public class Payment : EmbeddedObject
    {
        public Payment()
        {

        }
        public Payment(DateTime date, decimal vaalue)
        {
            Date = date;
            Value = vaalue;
        }

        public DateTimeOffset Date { get; set; }
        public decimal Value { get; set; }
        public string DateText => this.Date.ToLocalTime().DateTime.ToShortDateString();
    }
}