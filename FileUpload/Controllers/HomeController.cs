using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            this._db = db;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           List<Product> products= _db.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create() 
       
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)

        {
            if (ModelState.IsValid)
            {
                var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(filepath)) 
                {
                    Directory.CreateDirectory(filepath);
                
                }

                var fullpath = Path.Combine(filepath,product.Picture.FileName);
                using (var fileLocation=new FileStream(fullpath,FileMode.Create))
                {
                    await product.Picture.CopyToAsync(fileLocation);
                }

                product.PicturePath = product.Picture.FileName;

                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else {
                return View(product);
            }
          
        }
    }
}
