using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLTClothes.Filters;
using HLTClothes.Models;

namespace HLTClothes.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class OrderController : Controller
    {
        
        // GET: Admin/Order
        public ActionResult Index()
        {
            ClothesDBContext clothesDBContext = new ClothesDBContext();
            List<Order> lstod = clothesDBContext.orders.ToList();
            return View(lstod);
        }

        public ActionResult Detail(int id)
        {
            ClothesDBContext clothesDBContext = new ClothesDBContext();
            List<OrderDetail> lstoddt = clothesDBContext.orderDetails.Where(row => row.OrderID == id).ToList();
            ViewBag.ID = lstoddt.Find(row => row.OrderID == id).OrderID;
            return View(lstoddt);
        }
    }
}