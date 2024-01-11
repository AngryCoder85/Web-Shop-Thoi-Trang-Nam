using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HLTClothes.Models;

namespace HLTClothes.ApiControllers
{
    public class OrdersController : ApiController
    {
        public List<Order> Get()
        {
            ClothesDBContext clothesDBContext = new ClothesDBContext();
            List<Order> orders = clothesDBContext.orders.ToList();
            return orders;
        }
    }
}
