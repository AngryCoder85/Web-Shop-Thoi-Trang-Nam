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
    public class CategoryController : Controller
    {
        ClothesDBContext dBContext = new ClothesDBContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Category> categories = dBContext.Categories.ToList();
            return View(categories);
        }

        public ActionResult Edit(int id)
        {
            Category cat = dBContext.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category cate)
        {
            Category cat = dBContext.Categories.Where(row => row.CategoryID == cate.CategoryID).FirstOrDefault();
            cat.CategoryName = cate.CategoryName;
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cate)
        {
            dBContext.Categories.Add(cate);
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}