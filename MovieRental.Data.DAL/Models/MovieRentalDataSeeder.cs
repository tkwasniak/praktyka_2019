using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Data.DAL.Models
{
    public class MovieRentalDataSeeder: CreateDatabaseIfNotExists<MovieRentalEntities>
    {
        //protected override void Seed(MovieRentalEntities context)
        //{
        //    Film film = new Film
        //    {
        //        Title = "Zorro",
        //        Release = new DateTime(1980, 3, 12),
        //        Category = "Horror",
        //        Director = "John Paul",
        //        Language = "English", 
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Boogeyman",
        //        Release = new DateTime(1990, 4, 12),
        //        Category = "Horror",
        //        Director = "Juas Yuhan",
        //        Language = "Japanese",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Cloverfield",
        //        Release = new DateTime(2017, 4, 12),
        //        Category = "Comedy",
        //        Director = "Larry Paul",
        //        Language = "English",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Patriot",
        //        Release = new DateTime(2005, 6, 2),
        //        Category = "Drama",
        //        Director = "Edwin Van",
        //        Language = "English",
        //        Version = "Subtitles"
        //    };

        //    film = new Film
        //    {
        //        Title = "Ampra 03",
        //        Release = new DateTime(1996, 3, 13),
        //        Category = "Comedy",
        //        Director = "Rosette Yiri",
        //        Language = "French",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Secret Window",
        //        Release = new DateTime(2002, 5, 19),
        //        Category = "Action",
        //        Director = "David Flynch",
        //        Language = "English",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Grudge",
        //        Release = new DateTime(2000, 3, 13),
        //        Category = "Horror",
        //        Director = "Charles Brot",
        //        Language = "Spanish",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    film = new Film
        //    {
        //        Title = "Clash Of The Titans",
        //        Release = new DateTime(1996, 3, 13),
        //        Category = "Action",
        //        Director = "Patric Stew",
        //        Language = "English",
        //        Version = "Subtitles"
        //    };
        //    context.Films.Add(film);

        //    base.Seed(context);
        //}
    }
}
