using System.ComponentModel.DataAnnotations;

namespace EduMaterial.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Please Name Surname!")]
        public string FullName { get; set; }




        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please Username!")]
        public string UserName { get; set; }



        [Display(Name = "E-Posta Adress")]
        [Required(ErrorMessage = "Please E-Posta!")]
        [EmailAddress(ErrorMessage = "Please enter valid your e-mail!")]
        public string Email { get; set; }



        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Password!")]
        public string Password { get; set; }



        [Display(Name = "Again Password")]
        [Required(ErrorMessage = "Please Again Password!")]
        [Compare("Password", ErrorMessage = "not same Password!")]
        public string PasswordConfirm { get; set; }
    }
}
