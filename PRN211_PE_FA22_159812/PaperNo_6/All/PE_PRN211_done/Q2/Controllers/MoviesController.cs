using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2.Models;

namespace Q2.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Producer_Movie(int pid)
        {
            using (var db = new PE_PRN_Fall22B1Context())
            {
                ViewBag.producerList = db.Producers.ToList();
             
                    ViewBag.MovieList = db.Movies.Include("Genres").Include("Producer").Include("Director").Where(x=>x.ProducerId == pid).ToList();
               
            }
            return View();
        }
    }
}
