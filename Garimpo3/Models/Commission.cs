using MongoDB.Bson;
using Realms;

namespace Garimpo3.Models
{
    public class Commission : EmbeddedObject
    {
        public Commission()
        {

        }
        public Commission(Peon peon, decimal commission)
        {
            this.PeonId = peon.Id;
            this.Value = commission;
        }

        public ObjectId PeonId { get; set; }
        public decimal Value { get; set; }
    }
}