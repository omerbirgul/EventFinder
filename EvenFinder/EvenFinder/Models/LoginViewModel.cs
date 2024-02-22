using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="E-Mail")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="{0} alani en az {2} karakter uzunluğunda olmalıdır. ", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string? Password { get; set; }
    }
}
