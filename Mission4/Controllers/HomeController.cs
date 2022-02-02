using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDBContext coolContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieDBContext somethign)
        {
            _logger = logger;
            coolContext = somethign;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = coolContext.Category.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Form(FavoriteMovie ar)
        {
            if (ModelState.IsValid)
            {
                coolContext.Add(ar);
                coolContext.SaveChanges();

                return View("ConfirmationPage");
            }
            else
            {
                ViewBag.Categories = coolContext.Category.ToList();
                return View();
            }
            //Another option
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var coolData = coolContext.FavoriteMovies
                .Include( x => x.Category)
                .ToList();
            return View(coolData);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = coolContext.Category.ToList();

            var movie = coolContext.FavoriteMovies.Single(y => y.MovieId == movieid);

            return View("Form", movie);
        }

        [HttpPost]
        public IActionResult Edit(FavoriteMovie fm)
        {
            coolContext.Update(fm);
            coolContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = coolContext.FavoriteMovies.Single(y => y.MovieId == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete (FavoriteMovie fm)
        {
            coolContext.FavoriteMovies.Remove(fm);
            coolContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
