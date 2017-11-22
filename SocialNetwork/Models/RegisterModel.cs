using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required.", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required", AllowEmptyStrings = false)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Date of birth is required", AllowEmptyStrings = false)]
        public string BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}