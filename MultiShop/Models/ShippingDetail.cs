using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultiShop.Models
{
    public class ShippingDetail
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter District")]
        public string District { get; set; }
        [Required(ErrorMessage = "Enter Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Enter Postal Code")]
        public string PostalCode { get; set; }
        
    }
}