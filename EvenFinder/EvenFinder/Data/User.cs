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
        public string? PhoneNumber { get; set; }
    }
}
