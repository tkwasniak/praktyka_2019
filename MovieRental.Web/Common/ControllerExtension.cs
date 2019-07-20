using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Web.Common
{
    public static class ControllerExtension
    {
        public static string RenderPartialView(this Controller controller, string viewName, object model)
        {
            viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            controller.ViewData.Model = model;
            var viewData = new ViewDataDictionary(model);
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, viewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
