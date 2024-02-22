using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
