using SQLite;
using System;

namespace Garimpo3.Models
{
    public class Production
    {
        public Production()
        {

        }
        public Production(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
