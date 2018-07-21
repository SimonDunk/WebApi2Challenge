using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        //constructor uses dependency injection to inject the database context into the controller
        public ProductController(ProductContext context)
        {
            _context = context;

            //constructor creates an item for the in memory database if one doesn't exist
            if (_context.ProductList.Count() == 0)
            {
                _context.ProductList.Add(new Product { Description = "large tv", Model = "A100", Brand = "GL" });
                _context.SaveChanges();
            }
        }

        //MVC automatically serializes object to JSON and displays on browser
        //GET /api/Product
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.ProductList.ToList();
        }

        //uniquely identifying product by the value {id} in the route URL
        //GET /api/Product/{id}
        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetById(string id)
        {
            var item = _context.ProductList.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        //identify all products with the same description
        //GET /api/Product/desc/{desc}
        [HttpGet("description/{description}", Name = "DescriptionList")]
        public ActionResult<List<Product>> GetByDescription(string desc)
        {
            var items = _context.ProductList.Where(p => p.Description == desc);
            if (items == null)
            {
                return NotFound();
            }
            return items.ToList();
        }

        //identify all products with the same model
        //GET /api/Product/model/{model}
        [HttpGet("model/{model}", Name = "ModelList")]
        public ActionResult<List<Product>> GetByModel(string model)
        {
            var items = _context.ProductList.Where(p => p.Model == model);
            if (items == null)
            {
                return NotFound();
            }
            return items.ToList();
        }

        //identify all products with the same brand
        //GET /api/Product/brand/{brand}
        [HttpGet("brand/{brand}", Name = "BrandList")]
        public ActionResult<List<Product>> GetByBrand(string brand)
        {
            var items = _context.ProductList.Where(p => p.Brand == brand);
            if(items == null)
            {
                return NotFound();
            }
            return items.ToList();
        }

        //Creating new product
        //POST /api/product
        [HttpPost]
        public IActionResult Create(Product item)
        {
            _context.ProductList.Add(item);
            _context.SaveChanges();

            //returns a 201 response (POST) and creates a new resource on the server
            //adds a location header to response which specifies URI of the newly created item
            //uses GetProduct named route to create the URL defined by GetById
            //MVC gets the value of the item from the HTTP request
            return CreatedAtRoute("GetProduct", new { id = item.Id }, item);
        }

        //updating a product 
        //PUT /api/product/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, Product item)
        {
            var prod = _context.ProductList.Find(id);
            if(prod == null)
            {
                return NotFound();
            }

            prod.Description = item.Description;
            prod.Model = item.Model;
            prod.Brand = item.Brand;

            _context.ProductList.Update(prod);
            _context.SaveChanges();
            //Update response 204
            return NoContent();
        }

        //delete a product
        //DELETE /api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var prod = _context.ProductList.Find(id);
            if(prod == null)
            {
                return NotFound();
            }

            _context.ProductList.Remove(prod);
            _context.SaveChanges();
            //Delete response 204
            return NoContent();
        }
    }
}
