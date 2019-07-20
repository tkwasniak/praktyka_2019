using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Interfaces;
using MovieRental.Core.Contracts.Models;
using MovieRental.Web.Common;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using MovieRental.Web.ModelsBuilder;
using System;
using System.Web.Mvc;
namespace MovieRental.Web.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService filmService;
        private const int pageSize = 5;
        public FilmController(IFilmService _fIlmService)
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
                var result = filmService.Create(FilmMapper.Mapping.Map<FilmViewModel, FilmModel>(fvm));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Errors = ModelState.Values }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Films(int page = 1, string sortOrder = "Title")
        {
            Enum.TryParse(sortOrder, out SortOrder sortOrderEnum);

            var totalPages = (int)Math.Ceiling((double)filmService.Count() / pageSize);
            var response = filmService.GetPaged(sortOrderEnum, page, pageSize);
            var path = Url.Action(nameof(this.Films)) + "?page={0}&sortOrder={1}";

            return PartialView(new FilmsViewModel
            {
                Films = FilmModelBuilder.GetFilmViewModelList(response.Data),
                Pagination = new PaginationViewModel(path, page, totalPages),
            });
        }

        [HttpPost]
        public ActionResult DeleteFilm(int id)
        {
            if (id != 0)
            {
                var response = filmService.Delete(id);
                return Json(response);
            }
            return Json(new { HasSucceeded = false, Errors = "Invalid id" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult UpdateFilm(int id)
        {
            var response = filmService.GetById(id);
            if (response.HasSucceeded)
            {
                var view = this.RenderPartialView("UpdateFilm", FilmModelBuilder.GetFilmViewModel(response.Data));
                return Json(new { response, view }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateFilm(FilmViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                FilmModel fm = FilmMapper.Mapping.Map<FilmViewModel, FilmModel>(fvm);
                filmService.Update(fm);
                return Json(new { HasSucceeded = true }, JsonRequestBehavior.AllowGet);
            }
            var view = this.RenderPartialView("UpdateFilm", fvm);
            return Json(new { HasSucceeded = false, view }, JsonRequestBehavior.AllowGet);
        }

    }
}