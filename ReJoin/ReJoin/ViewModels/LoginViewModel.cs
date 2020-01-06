using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReJoin.ViewModels
{
    public class LoginViewModel
    {
        public RegisterViewModel Register { get; set; }
        public LogingInViewModel Login { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Enter Email")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LogingInViewModel
    {

        [Required(ErrorMessage = "Entered Email ")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Entered Password ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}