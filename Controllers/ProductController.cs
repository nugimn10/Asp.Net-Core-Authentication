using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_core_auth_task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Asp.Net_core_auth_task.Controllers
{
    [ApiController]
    [Route("product")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly TokoKokoContext _context;
        public ProductController(TokoKokoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var pr = _context.Products;
            return Ok(new {message = "success retrieve data", status = true, data = pr});
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var pr = _context.Products.First(i => i.Id == id);
            return Ok(pr);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            var pr = _context.Products.First(i => i.Id == id);
            pr.Name = "Banana";
            _context.SaveChanges();
            return Ok(pr);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var pr = _context.Products.First(i => i.Id == id);
            _context.Products.Remove(pr);
            _context.SaveChanges();
            return Ok(pr);
        }
    }
}