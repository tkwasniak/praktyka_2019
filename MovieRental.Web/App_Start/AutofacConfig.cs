using Autofac;
using Autofac.Integration.Mvc;
using MovieRental.Core.Logic.AutofacModule;
using MovieRental.Core.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Web.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<FilmService>();
            builder.RegisterModule(new FilmServiceModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}