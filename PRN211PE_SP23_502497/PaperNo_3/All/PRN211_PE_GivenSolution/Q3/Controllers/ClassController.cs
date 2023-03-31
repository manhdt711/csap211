using Microsoft.AspNetCore.Mvc;
using Q3.Models;
namespace Q3.Controllers
{
    public class ClassController : Controller
    {
        private readonly PE_PRN211_23SprB1Context _context = new();
        public IActionResult Index(int employeeId)
        {
            ViewBag.ClassList = _context.Classes.ToList();
            ViewBag.clList = _context.Classes.Where(x=>x.Grade==employeeId).ToList();
            return View();
        }
    }
}
