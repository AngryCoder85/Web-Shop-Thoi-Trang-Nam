using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HLTClothes.Models;
using HLTClothes.Filters;

namespace HLTClothes.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string search = "", int trang = 1, string sort = "")
        {
            ClothesDBContext dBContext = new ClothesDBContext();

            //Search
            List<Product> prolst = dBContext.Products.Where(row => row.ProductName.Contains(search)).ToList();
            List<Category> catlst = dBContext.Categories.ToList();
            ViewBag.Category = catlst;

            //Sort
            switch (sort)
            {
                case "PriceProDESC":
                    prolst = prolst.OrderByDescending(row => row.Price).ToList();
                    break;
                case "PriceProASC":
                    prolst = prolst.OrderBy(row => row.Price).ToList();
                    break;
                case "NewUpload":
                    prolst = prolst.OrderByDescending(row => row.DateOfUpload).ToList();
                    break;
                case "PrdNameASC":
                    prolst = prolst.OrderBy(row => row.ProductName).ToList();
                    break;
                case "T-SHIRTS":
                    prolst = prolst.Where(row => row.Category.CategoryName == "T-SHIRTS").ToList();
                    break;
                case "JEANS":
                    prolst = prolst.Where(row => row.Category.CategoryName == "JEANS").ToList();
                    break;
                case "PANTS":
                    prolst = prolst.Where(row => row.Category.CategoryName == "PANTS").ToList();
                    break;
                case "JACKETS":
                    prolst = prolst.Where(row => row.Category.CategoryName == "JACKETS").ToList();
                    break;
            }

            //page
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(prolst.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (trang - 1) * NoOfRecordPerPage;
            ViewBag.Trang = trang;
            ViewBag.NoOfPages = NoOfPages;
            prolst = prolst.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();


            return View(prolst);
        }

        public ActionResult Detail(int id)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            Product pro = dBContext.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }


        public ActionResult Create()
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            ViewBag.Brand = dBContext.Brands.ToList();
            ViewBag.Gender = dBContext.Gender.ToList();
            ViewBag.Category = dBContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product prd)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            if (ModelState.IsValid)
            {
                if (prd.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(prd.ImageUpload.FileName);
                    string extension = Path.GetExtension(prd.ImageUpload.FileName);
                    filename = filename + extension;
                    prd.ImageUrl = filename;
                    dBContext.Products.Add(prd);
                    dBContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            ViewBag.Brand = dBContext.Brands.ToList();
            ViewBag.Gender = dBContext.Gender.ToList();
            ViewBag.Category = dBContext.Categories.ToList();
            Product product = dBContext.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            Product product = dBContext.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();

            //Start Update
            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.BrandID = pro.BrandID;
            product.CategoryID = pro.CategoryID;
            product.GenderID = pro.GenderID;
            product.DateOfUpload = pro.DateOfUpload;
            product.ShowOnIndex = pro.ShowOnIndex;
            product.Status = pro.Status;

            //Xu ly hinh anh
            if (pro.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                string extension = Path.GetExtension(pro.ImageUpload.FileName);
                filename = filename + extension;
                pro.ImageUrl = filename;
                product.ImageUrl = pro.ImageUrl;
            }
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            Product prd = dBContext.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(prd);
        }

        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            ClothesDBContext dBContext = new ClothesDBContext();
            Product prd = dBContext.Products.Where(row => row.ProductID == id).FirstOrDefault();
            dBContext.Products.Remove(prd);
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}