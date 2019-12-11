using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsCategories.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(Context context)
        {
            dbContext = context;
        }
        // =========== ROUTES ============

        // Show One Category by Id
        [HttpGet("/categories/{id}")]
        public IActionResult Category(int id)
        {
            // ViewModel contains a blank Association model,
            // The Category based on the "id" param,
            // The associated products on this catgeory,
            // All products and their associations
            ViewModel catview = new ViewModel
            {
                Association = new ProdCat(),
                OneCat = dbContext.Categories.SingleOrDefault(c => c.CatId == id),
                Associations = dbContext.ProdCats.Include(pc => pc.Product).Where(p => p.CatId == id).ToList(),
                AllProds = dbContext.Products
                .Include(p => p.Associations)
                .ToList()
            };
            return View(catview);
        }
        // Show one Product by Id
        [HttpGet("/products/{id}")]
        public IActionResult Product(int id)
        {
            // ViewModel contains a blank Association model,
            // The Product based on the "id" param,
            // The associated categories  on this product,
            // All categories  and their associations
            ViewModel prodview = new ViewModel
            {
                Association = new ProdCat(),
                OneProd = dbContext.Products.SingleOrDefault(c => c.ProdId == id),
                Associations = dbContext.ProdCats.Include(pc => pc.Category).Where(p => p.ProdId == id).ToList(),
                AllCats = dbContext.Categories
                .Include(p => p.Associations)
                .ToList()
            };
            return View(prodview);
        }

        // Show All Products
        [HttpGet("/products")]
        public IActionResult Products()
        {
            // ViewModel contains a blank Product model,
            // All products
            ViewModel prodview = new ViewModel
            {
                AllProds = dbContext.Products.ToList(),
                OneProd = new Product()
            };
            return View(prodview);
        }
        // POST method for creating a product
        [HttpPost("/products")]
        public IActionResult Product(ViewModel data)
        {
            // I bring in the entire viewmodel and parse out what I need, 
            // ie. the product data
            Product prod = data.OneProd;

            if(ModelState.IsValid)
            {
                dbContext.Add(prod);
                dbContext.SaveChanges();
                return RedirectToAction("Products");
            }
            else{
                // repack the original viewmodel from the Products IActionResult above
                // and send the viewmodel back thru
                data.OneProd = prod;
                data.AllProds = dbContext.Products.ToList();
                return View("Products", data);
            }
        }
        //Show All Categories
        [HttpGet("/categories")]
        public IActionResult Categories()
        {            
            // ViewModel contains a blank Category model,
            // All categories
            ViewModel catview = new ViewModel
            {
                OneCat = new Category(),
                AllCats = dbContext.Categories.ToList()
            };
            return View(catview);
        }
        // POST method for creating a category
        [HttpPost("/categories")]
        public IActionResult Category(ViewModel data)
        {
            // I bring in the entire viewmodel and parse out what I need, 
            // ie. the category data
            Category cat = data.OneCat;
            if(ModelState.IsValid)
            {
                dbContext.Add(cat);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else{
                // repack the original viewmodel from the Category IActionResult above
                // and send the viewmodel back thru
                data.OneCat = cat;
                data.AllCats = dbContext.Categories.ToList();
                return View("Categories", data);
            }
        }
        [HttpPost("/associate")]
        public IActionResult Associate(ViewModel data)
        {
            ProdCat assoc = data.Association;
            if(ModelState.IsValid)
            {
                dbContext.Add(assoc);
                dbContext.SaveChanges();
                // to pass parameters thru, create anonymous objects like below:
                return RedirectToAction("Category", new {id = assoc.CatId});
            }
            else
            {
                return View("Category");
            }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
