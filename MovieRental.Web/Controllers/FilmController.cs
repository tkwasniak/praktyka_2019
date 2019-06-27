using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Services;
using MovieRental.Core.Logic.Models;
using MovieRental.Core.Logic.Services;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieRental.Web.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService filmService;


        public FilmController(FilmService _fIlmService)
        {
            this.filmService = _fIlmService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<IFilmModel> filmModelList = filmService.GetAllFilms();
            IEnumerable<FilmViewModel> filmViewModelList = FilmMapper.Default.Map<IEnumerable<IFilmModel>, IEnumerable<FilmViewModel>>(filmModelList);
            return View(filmViewModelList);
        }

        [HttpGet]
        public PartialViewResult AddFilm()
        {
            return PartialView();
        }

        //[HttpGet]
        //public ActionResult AddFilm()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult AddFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Default.Map<FilmViewModel, FilmModel>(fvm);
                filmService.AddFilm(fm);
                return Json(new { success = true });
            }
            return PartialView(fvm);
        }


        [HttpPost]
        public JsonResult DeleteFilm(int id)
        {
            if (id != 0)
            {
                filmService.DeleteFilm(id);
                return Json(new { success = true } );
            }
            return Json(new { success = false } );
        }

        [HttpGet]
        public ActionResult EditFilm(int id)
        {
            IFilmModel fm = filmService.GetFilm(id);
            FilmViewModel fvm = FilmMapper.Default.Map<IFilmModel, FilmViewModel>(fm);
            return View(fvm);
        }

        public ActionResult EditFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Default.Map<FilmViewModel, FilmModel>(fvm);
                filmService.EditFilm(fm);
                return RedirectToAction(nameof(Index));
            }
            return View(fvm);
        }

    }
}