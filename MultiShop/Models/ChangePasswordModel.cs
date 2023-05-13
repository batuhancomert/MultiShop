using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MultiShop.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Reset New Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords Are Not The Same")]
        public string ConNewPassword { get; set; }
    }
}