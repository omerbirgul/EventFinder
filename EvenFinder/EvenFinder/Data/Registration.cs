using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Data
{
    public class Registration
    {
        [Key]
        public int RegisterId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime RegisterTime { get; set; }
    }
}
