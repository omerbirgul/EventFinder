using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? EventLocation { get; set; }
        public string? EventImage { get; set; }
        public int RegisterCount { get; set; }

    }
}
