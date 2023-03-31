using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eStore.Controllers
{
    public class OrderDetailController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PRN_Ass2Context _context = new();
        // GET: OrderDetailController
        public ActionResult Index(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            var ode = OrderDetail.GetOrderbyMemberID(id).ToList();
            return View(ode);
        }

        // GET: OrderDetailController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.OrderDetails.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: OrderDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
