using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HLTClothes.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Required(ErrorMessage = "Tên mặt hàng không được để trống")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Phải chọn thương hiệu")]
        public Nullable<long> BrandID { get; set; }
        [Required(ErrorMessage = "Chọn đối tượng phù hợp của sản phẩm")]
        public Nullable<long> GenderID { get; set; }
        [Required(ErrorMessage = "Chọn phân loại sản phẩm")]
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> SizeID { get; set; }
        [Required(ErrorMessage = "Giá sản phẩm không được bỏ trống")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfUpload { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<bool> ShowOnIndex { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Size Size { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}