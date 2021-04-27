using MongoDB.Bson;
using Realms;

namespace Garimpo3.Models
{
    public class Commission : RealmObject
    {
        public Commission()
        {

        }
        public Commission(Peon peon, decimal commission)
        {
            this.Peon = peon;
            this.Value = commission;
        }

        [MapTo("_id"), PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public Peon Peon { get; set; }
        public Production Production { get; set; }
        public decimal Value { get; set; }
    }
}