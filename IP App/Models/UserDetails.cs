using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IP_App.Models
{
    public class UserDetails
    {
        [Required]
        public int User_ID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name ="First Name")]
        public string User_First_Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last Name")]
        public string User_Last_Name { get; set; }
        [Required]
        [Display(Name = "Email ID")]
        public string User_Emaild { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string User_Password { get; set; }
    }
}