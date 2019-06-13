using MovieRental.Core.Logic.Models;
using MovieRental.Core.Logic.Services;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Web.Controllers
{
    public class FilmController : Controller
    {
        private readonly FIlmService filmService;

        public FilmController()
        {
            filmService = new FIlmService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNewFilm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = new FilmModel();
                filmService.AddNewFilm(FilmMapper.Default.Map(fvm, fm));
                return RedirectToAction(nameof(Index));
            }
            return View(fvm);
        }

    }
}