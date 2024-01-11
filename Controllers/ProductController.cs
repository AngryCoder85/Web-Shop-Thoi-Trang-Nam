using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HLTClothes.Models;

namespace HLTClothes.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search="", int trang = 1, string sort = "")
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
        
        
    }
}