using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.Models
{
    public class OrderDetail
    {
        [Key]
        public long DetailID { get; set; }
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public decimal Price { get; set; }
        public int QuantitySale { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}