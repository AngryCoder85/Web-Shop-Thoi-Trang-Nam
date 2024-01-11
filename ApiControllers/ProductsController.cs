using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HLTClothes.Models;

namespace HLTClothes.ApiControllers
{
    public class ProductsController : ApiController
    {
        public List<Product> Get()
        {
            ClothesDBContext clothesDBContext = new ClothesDBContext();
            List<Product> products = clothesDBContext.Products.ToList();
            return products;
        }
    }
}
