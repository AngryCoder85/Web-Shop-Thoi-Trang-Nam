using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLTClothes.Models;
using HLTClothes.Filters;

namespace HLTClothes.Controllers
{
    public class ShoppingCartController : Controller
    {
        ClothesDBContext dBContext = new ClothesDBContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        [MyAuthenFilter]
        public ActionResult AddtoCart(int id)
        {
            Product pro = dBContext.Products.FirstOrDefault(row => row.ProductID == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public ActionResult ShowtoCart()
        {
            if(Session["Cart"] == null)
            {
                return RedirectToAction("ShowtoCart", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult UpdateQuantityCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idPrd = int.Parse(form["ProductID"]);
            int Quantity = int.Parse(form["Quantity"]);
            cart.UpdateQuantity(idPrd, Quantity);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }

        public ActionResult ShoppingSucess()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.OrderDate = DateTime.Now;
                _order.Phone = form["Phone"];
                _order.Address = form["Address"];
                dBContext.orders.Add(_order);
                foreach(var item in cart.Items)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderID = _order.OrderID;
                    orderDetail.ProductID = item.ProductShopping.ProductID;
                    orderDetail.Price = (decimal)item.ProductShopping.Price;
                    orderDetail.QuantitySale = item.ShoppingQuantity;
                    dBContext.orderDetails.Add(orderDetail);
                }
                dBContext.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("ShoppingSucess", "ShoppingCart");
            }
            catch
            {
                return Content("Error Checkout");
            }
        }
    }
}