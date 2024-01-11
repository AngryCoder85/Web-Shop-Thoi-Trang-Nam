using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLTClothes.Models
{
    public class CartItem
    {
        public Product ProductShopping { get; set; }
        public int ShoppingQuantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(row => row.ProductShopping.ProductID == pro.ProductID);
            if(item == null)
            {
                items.Add(new CartItem{
                    ProductShopping = pro,
                    ShoppingQuantity = quantity
                });
            }
            else
            {
                item.ShoppingQuantity += quantity;
            }
        }
        public void UpdateQuantity(int id, int _quantity)
        {
            var item = items.Find(row => row.ProductShopping.ProductID == id);
            if(item != null)
            {
                item.ShoppingQuantity = _quantity;
            }
        }
        public double MoneyTotal()
        {
            var total = items.Sum(row => row.ProductShopping.Price * row.ShoppingQuantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(row => row.ProductShopping.ProductID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}