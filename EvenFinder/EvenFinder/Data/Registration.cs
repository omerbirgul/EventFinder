using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Data
{
    public class Registration
    {
        [Key]
        public int RegisterId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public DateTime RegisterTime { get; set; }
    }
}
