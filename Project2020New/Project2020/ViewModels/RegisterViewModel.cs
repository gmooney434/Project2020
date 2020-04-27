using Microsoft.AspNetCore.Mvc;
using Project2020.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "ulster.ac.uk", ErrorMessage = "Email domain must be ulster.ac.uk")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [BCode(bCodeFormat: "B", ErrorMessage ="Must begin with a B")]
        public string B_Code { get; set; }
    }
}
