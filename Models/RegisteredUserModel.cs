using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beltexam.Models
{
    public class RegisterUserModel
    {

        [Required (ErrorMessage="Name is required")]
        [MinLength(2)]
        [Display(Name= "Name")]
        public string Name { get; set; }
        
        
        [Required (ErrorMessage="Alias is required")]
        [MinLength(2)]
        [Display(Name= "Alias")]
        public string Alias { get; set; }
        
        
        [Required (ErrorMessage="Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name= "Email")]
        public string Email { get; set; }
        
        
        [Required (ErrorMessage="Password is required")]
        [MinLength(8)]
        [Display(Name= "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name= "Confirm Password")]
        public string C_Password {get; set;}

    }
}