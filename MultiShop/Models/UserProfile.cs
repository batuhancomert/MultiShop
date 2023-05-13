using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MultiShop.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Username")]
        public string UserName { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}