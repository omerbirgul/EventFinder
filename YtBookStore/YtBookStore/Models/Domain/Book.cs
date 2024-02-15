using System.ComponentModel.DataAnnotations;

namespace YtBookStore.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int TotalPage { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int GenreId { get; set; }

    }
}
