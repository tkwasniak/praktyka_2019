using Autofac;
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
            builder.RegisterType<UnitOfWork>();
            base.Load(builder);
        }
    }
}
