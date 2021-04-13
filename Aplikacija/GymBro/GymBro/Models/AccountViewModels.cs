using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymBro.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Neophodno je uneti e-mail!")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Nevalidna e-mail adresa!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Neophodno je uneti ime!")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti prezime!")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti mesto stanovanja!")]
        [Display(Name = "Mesto stanovanja")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti datum rođenja!")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti pol!")]
        [Display(Name = "Pol")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti e-mail!")]
        [EmailAddress(ErrorMessage = "Nevalidna e-mail adresa!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Neophodno je uneti lozinku!")]
        [StringLength(100, ErrorMessage = "{0} mora da bude minimum {2} karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i lozinka za potvrdu se ne poklapaju.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora da bude minimum {2} karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i lozinka za potvrdu se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}
