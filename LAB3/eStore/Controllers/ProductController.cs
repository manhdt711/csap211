using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eStore.Controllers
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        // GET: ProductController
        private readonly PRN_Ass2Context _context = new();
        public ActionResult Index(string searchString)
        {
            IQueryable<Product> ProductList;

            if (!String.IsNullOrEmpty(searchString))
            {
                ProductList = _context.Products.Where(s => s.ProductName.Contains(searchString));
            }
            else
            {
                ProductList = _context.Products;
            }

            return View(ProductList.ToList());
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p=>p.ProductId== id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create() => View();

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Products.Add(pro);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pro);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p=>p.ProductId== id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                if(id != pro.ProductId)
                {
                    return NotFound();
                }
                if(ModelState.IsValid)
                {
                    _context.Products.Update(pro);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p=> p.ProductId== id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p=>p.ProductId== id);
                Product.DeleteProduct(product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
