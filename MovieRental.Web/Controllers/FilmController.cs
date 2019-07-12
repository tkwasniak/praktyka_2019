using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Services;
using MovieRental.Core.Logic.Models;
using MovieRental.Core.Logic.Services;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using MovieRental.Web.ModelsBuilder;
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
        private const int pageSize = 5;
        public FilmController(FilmService _fIlmService)
        {
            this.filmService = _fIlmService;
        }

        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult CreateFilm() => View(new FilmViewModel());

        [HttpPost]
        public ActionResult CreateFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Default.Map<FilmViewModel, FilmModel>(fvm);
                var result = filmService.Create(fm);
                return Json(result);
            }
            return PartialView(fvm);
        }

        [HttpGet]
        public ActionResult Films(int page = 1, string sortOrder = "Title")
        {
            Enum.TryParse(sortOrder, out SortOrder sortOrderEnum);
            var totalPages = (int)Math.Ceiling((double) filmService.Count() / pageSize);
            var filmsModel = filmService.GetPaged(sortOrderEnum, page, pageSize);

            IEnumerable<FilmViewModel> filmsViewModel =
                FilmMapper.Default.Map<IEnumerable<IFilmModel>, IEnumerable<FilmViewModel>>(filmsModel);


            var path = Url.Action("Films");

            return PartialView(new FilmsViewModel
            {
                Films = filmsViewModel,
                Pagination = new PaginationViewModel(path + "?page={0}&sortOrder={1}", page, totalPages),
            });
        }


        [HttpPost]
        public ActionResult DeleteFilm(int id)
        {
            id = -3;
            if (id != 0)
            {
                var result = filmService.Delete(id);
                return Json(result);
            }
            return Json(new { success = false });
        }


        [HttpGet]
        public ActionResult UpdateFilm(int id)
        {
            var filmModel = filmService.GetById(id);

            var film = FilmMapper.Default.Map<FilmModel, FilmViewModel>(filmModel as FilmModel);
            return PartialView("UpdateFilm", film);
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