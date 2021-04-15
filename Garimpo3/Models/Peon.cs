using SQLite;

namespace Garimpo3.Models
{
    public class Peon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
