using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLTClothes.Models;
using HLTClothes.Filters;

namespace HLTClothes.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            ViewBag.Gender = dBContext.Gender.ToList();
            ViewBag.Brand = dBContext.Brands.ToList();
            ViewBag.Category = dBContext.Categories.ToList();
            return PartialView("_AdminNavBar");
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}