using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.Models
{
    public class Size
    {
        [Key]
        public long SizeID { get; set; }
        public string SizeName { get; set; }
    }
}