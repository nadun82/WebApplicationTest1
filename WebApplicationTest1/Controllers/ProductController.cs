﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationTest1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            
            List<Product> list = new List<Product>();
            list.Add(new Product { id = 11, name = "IPhone", description = "Apple 6 ", unitprice = 75000.25 });
            list.Add(new Product { id = 12, name = "Samsung", description = "Galaxy", unitprice = 175000.25 });
            list.Add(new Product { id = 13, name = "OPPO", description = "Oppo V5", unitprice = 45000.25 });
            list.Add(new Product { id = 14, name = "Huwawei", description = "Huwai 5X ", unitprice = 35000.25 });

            // throw new Exception("Test");
            //return StatusCode(404, errorReponse);
            return Ok(list);
            
        }

        [HttpPost]
        public IActionResult SaveProducts(Product product)
        {
            return Ok();
        }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
            public double unitprice { get; set; }
            public double subtotal { get; set; }

        }
    }
}
