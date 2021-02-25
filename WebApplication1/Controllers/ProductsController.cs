using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel data)
        {
            data.Name = HtmlEncoder.Default.Encode(data.Name);
            if (ModelState.IsValid)
            {
                if(data.Category.Id < 0 || data.Category.Id > 4)
                {
                    ModelState.AddModelError("Category.Id", "Category is not valid");
                    return View(data);

                }
                TempData["message"] = "Product inserted successfully";
                return View();

            }
            else
            {
                return View(data);
            }

           
        }

    }
}
