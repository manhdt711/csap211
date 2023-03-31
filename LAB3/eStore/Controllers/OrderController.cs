﻿using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eStore.Controllers
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PRN_Ass2Context _context = new();
        // GET: OrderController
        public ActionResult Index()
        {
            var orderList = _context.Orders.ToList();
            ViewBag.orderlist = orderList;
            return View(orderList);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create() => View();

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order orde)
        {
            try
            {
                if (id != orde.OrderId)
                    return NotFound();
                if (ModelState.IsValid)
                {
                    _context.Orders.Update(orde);
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Order.DeleteOrder(id);
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
