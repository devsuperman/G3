using MongoDB.Bson;
using Realms;
using System;

namespace Garimpo3.Models
{
    public class CustomUserData
    {
        [MapTo("_id")]
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public bool Blocked { get; set; }
        public DateTime LastSync { get; set; }
        public string DredgeId { get; set; }
    }
}
