using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Services;
using MovieRental.Core.Logic.Models;
using MovieRental.Core.Logic.Services;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MovieRental.Web.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService filmService;
        private const int pageSize = 3;
        public FilmController(FilmService _fIlmService)
        {
            this.filmService = _fIlmService;
        }

        [HttpGet]
        public ActionResult CreateFilm()
        {
            return PartialView("_CreateFilm", new FilmViewModel());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetFilms(int page = 1, string sortOrder = "Title")
        {
            Enum.TryParse(sortOrder, out SortOrder sortOrderEnum);
            var totalPages = (int)Math.Ceiling((double) filmService.Count() / pageSize);
            var filmsModel = filmService.GetPaged(sortOrderEnum, page, pageSize);

            IEnumerable<FilmViewModel> filmsViewModel =
                FilmMapper.Default.Map<IEnumerable<IFilmModel>, IEnumerable<FilmViewModel>>(filmsModel);

            var path = Url.Action("GetFilms");

            return PartialView("_Films", new FilmsViewModel
            {
                Films = filmsViewModel,
                Pagination = new PaginationViewModel(path + "?page={0}&sortOrder={1}", page, totalPages),
            });
        }

        [HttpPost]
        public ActionResult CreateFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Default.Map<FilmViewModel, FilmModel>(fvm);
                filmService.Create(fm);
                return PartialView("_FilmDetails", fvm);
            }
            return PartialView("_FilmDetails", fvm);
        }


        [HttpPost]
        public ActionResult DeleteFilm(int id)
        {
            if (id != 0)
            {
                filmService.Delete(id);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        [HttpGet]
        public ActionResult UpdateFilm(int id)
        {
            IFilmModel fm = filmService.GetById(id);
            FilmViewModel fvm = FilmMapper.Default.Map<IFilmModel, FilmViewModel>(fm);
            return PartialView("_UpdateFilm", fvm);
        }

        [HttpPost]
        public ActionResult UpdateFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Default.Map<FilmViewModel, FilmModel>(fvm);
                filmService.Update(fm);
                return Json(new { success = true });
            }
            return PartialView(fvm);
        }

    }
}