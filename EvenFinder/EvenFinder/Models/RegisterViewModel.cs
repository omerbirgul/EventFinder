using System.ComponentModel.DataAnnotations;

namespace EvenFinder.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string? Image { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "RepeatPassword")]
        [Compare(nameof(Password), ErrorMessage ="Passwords doesn't match!")]
        public string? ConfirmPassword { get; set; }


    }
}
