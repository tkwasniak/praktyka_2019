using Common.Logger;
using MovieRental.Data.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Web.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult General(string error = "")
        {
            ViewBag.Message = error;
            return View();
        }

        public ActionResult NotFound(string error = "")
        {
            ViewBag.Message = error;
            return View();
        }
    }
}