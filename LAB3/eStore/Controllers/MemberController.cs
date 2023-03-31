using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;


namespace eStore.Controllers
{
    public class MemberController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PRN_Ass2Context _context = new();
        // GET: MemberController
        public ActionResult Index()
        {
            var memList = _context.Members.ToList();
            return View(memList);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var mem = _context.Members.FirstOrDefault(m => m.MemberId== id);
            if(mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // GET: MemberController/Create
        public ActionResult Create() => View();

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member mem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Members.Add(mem);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(mem);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var mem = _context.Members.FirstOrDefault(m=>m.MemberId==id);
            if(mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member mem)
        {
            try
            {
                if(id != mem.MemberId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _context.Members.Update(mem);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var mem = _context.Members.FirstOrDefault(m => m.MemberId==id);
            if(mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Member.DeleteMember(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
        public ActionResult Login() => View();

        private readonly IConfiguration _config;

        public MemberController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Member mem)
        {
            string _adminEmail;
        string _adminPassword;
            // Read the AdminAccount settings from appsettings.json
            var adminAccount = _config.GetSection("AdminAccount");
            _adminEmail = adminAccount["Email"].ToString();
            _adminPassword = adminAccount["Password"].ToString();
            try
        {
            if (ModelState.IsValid)
            {
                    if (mem.Email.Equals(_adminEmail) && mem.Password.Equals(_adminPassword))
                    {
                        HttpContext.Session.SetString("sessionAccount", "admin");
                        return RedirectToAction("Index", "Member");
                    }
                        var Account = _context.Members.Where(s => s.Email.Equals(mem.Email) && s.Password == mem.Password).ToList();
                        Member accountMember = Account.FirstOrDefault();
                        if (Account.Any())
                        {
                        int memID = accountMember.MemberId;
                        HttpContext.Session.SetString("sessionAccount", memID.ToString()) ;
                        return RedirectToAction("Details", "Member", new { id = memID });
                    }

                }
                TempData["Message"] = "Invalid email or password. Please try again.";
                return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
                ViewBag.Message = ex.Message;
                return View();
            }
    }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
