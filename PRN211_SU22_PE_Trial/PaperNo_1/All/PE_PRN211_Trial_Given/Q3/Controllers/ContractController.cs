using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3.Models;
using System.Linq;

namespace Q3.Controllers
{
    public class ContractController : Controller
    {
        private readonly PE_PRN_Sum21Context _context = new();
        public IActionResult Index(int employeeId)
        {
            ViewBag.EmpList = _context.Employees.ToList();
            ViewBag.ConList = _context.Contracts.Include("Customer").Include("Employee").Where(c => c.EmployeeId == employeeId).ToList();
            return View();
        }
    }
}
