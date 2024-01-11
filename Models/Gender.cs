using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.Models
{
    public class Gender
    {
        [Key]
        public long GenderID { get; set; }
        public string GenerName { get; set; }
    }
}