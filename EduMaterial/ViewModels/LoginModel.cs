using System.ComponentModel.DataAnnotations;

namespace EduMaterial.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please UserName!")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Password!")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
