using CakeFinalApp.Models.Base;

namespace CakeFinalApp.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}
