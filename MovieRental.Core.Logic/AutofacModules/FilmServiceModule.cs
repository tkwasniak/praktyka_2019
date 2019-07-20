using Autofac;
using Common.Logger;
using MovieRental.Data.DAL.Interfaces;
using MovieRental.Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.AutofacModule
{
    public class FilmServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<LoggerFactory>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
