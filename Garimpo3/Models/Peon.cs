using Realms;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace Garimpo3.Models
{
    public class Peon : RealmObject
    {
        public Peon()
        {

        }
        public Peon(string name, string dredgId)
        {
            Name = name;
            DredgeId = dredgId;
        }

        [PrimaryKey, MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public decimal Balance { get; set; }
        
        public IList<Payment> Payments { get; }
        public string DredgeId { get; set; }

        internal void Update(string name, bool active)
        {
            this.Name = name;
            this.Active = active;
        }
    }
}
