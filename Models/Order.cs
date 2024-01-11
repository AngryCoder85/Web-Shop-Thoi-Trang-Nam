using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.Models
{
    public class Order
    {
        [Key]
        public long OrderID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Status { get; set; }

    }
}