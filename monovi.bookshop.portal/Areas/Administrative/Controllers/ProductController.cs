using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using monovi.bookstore.dal.Repository.IRepository;
using monovi.bookstore.model;

namespace monovi.bookstore.portal.Areas.Administrative.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateOrInsert(int? id)
        {
            Product product = null;
            if (id.HasValue)
            {
                product = unitOfWork.Product.Get(id.Value);
                if (product == null)
                    return NotFound();
                else
                    return View(product);
            }
            else
            {
                product = new Product();
                return View(product);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOrInsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    unitOfWork.Product.Add(product);
                }
                else
                {
                    unitOfWork.Product.Update(product);
                }
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Product> allProducts = unitOfWork.Product.GetAll();
            return Json(new { data = allProducts });
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product savedProduct = unitOfWork.Product.Get(id);
            if (savedProduct == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            else
            {
                unitOfWork.Product.Remove(savedProduct);
                unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successfull" });
            }
        }

    }
}
