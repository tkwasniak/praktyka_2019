using Moq;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Services;
using MovieRental.Data.DAL.Interfaces;
using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;
using NUnit.Framework;
using System;

namespace MovieRental.Test
{
    [TestFixture]
    public class CreateFilmTest
    {
        [Test]
        public void Create_ValidFilm_ShouldReturnSuccessResponse()
        {
            var film = new Film();
            var filmModel = new FilmModel
            {
                Title = "Dark Knight",
                Country = "USA",
                Director = "James Cameron",
                Category = FilmCategory.Action,
                Release = DateTime.Now,
                Rating = FilmRating.PG13
            };

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();

            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.True(response.HasSucceeded);
            Assert.That(response.Errors, Is.Null);
        }

        [Test]
        public void Create_NullFilm_ShouldReturnErrorResponse()
        {
            //Arrange
            var film = new Film();
            FilmModel filmModel = null;

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();


            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.False(response.HasSucceeded);
            CollectionAssert.Contains(response.Errors, "IFilmModel: Object is null");
        }


        [Test]
        public void Create_FilmWithId_ShouldReturnErrorResponse()
        {
            //Arrange
            var film = new Film();
            var filmModel = new FilmModel
            {
                Id = 32,
                Title = "Grudge",
                Country = "Japan",
                Director = "Loya Dri",
                Category = FilmCategory.Horror,
                Release = DateTime.Now,
                Rating = FilmRating.G
            };

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();


            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.False(response.HasSucceeded);
            Assert.NotNull(response.Errors);
            CollectionAssert.Contains(response.Errors, "Id should not be set");
        }


        [Test]
        public void Create_InvalidDate_ShouldReturnErrorResponse()
        {
            //Arrange
            var film = new Film();
            var filmModel = new FilmModel
            {
                Title = "14 days",
                Country = "USA",
                Director = "Abc abc",
                Category = FilmCategory.Western,
                Release = new DateTime(2030, 3, 3),
                Rating = FilmRating.G
            };

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();


            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.False(response.HasSucceeded);
            Assert.NotNull(response.Errors);
            Assert.That(response.Errors.Count == 1);
        }

        [Test]
        public void Create_ToShortDirectorName_ShouldReturnErrorResponse()
        {
            //Arrange
            var film = new Film();
            var filmModel = new FilmModel
            {
                Title = "14 days",
                Country = "USA",
                Director = "A",
                Category = FilmCategory.Western,
                Release = new DateTime(2000, 3, 3),
                Rating = FilmRating.G
            };

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();


            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.False(response.HasSucceeded);
            Assert.NotNull(response.Errors);
            Assert.That(response.Errors.Count == 1);
        }


        [TestCase("", "abc", "abc def", FilmCategory.Action, "2012, 3, 3", FilmRating.G)]
        [TestCase("abc", "", "abc def", FilmCategory.Action, "2012, 3, 3", FilmRating.G)]
        [TestCase("abc", "abc", "", FilmCategory.Action, "2012, 3, 3", FilmRating.G)]
        [TestCase("abc", "abc", "abc def", 100, "2012, 3, 3", FilmRating.G)]
        [TestCase("abc", "abc", "abc def", FilmCategory.Action, null, FilmRating.G)]
        [TestCase("abc", "abc", "abc def", FilmCategory.Drama, "2012, 3, 3", 100)]
        public void Create_InvalidFilm_ShouldReturnErrorResponse(
            string title, string country, string director, FilmCategory category, DateTime release, FilmRating rating )
        {
            //Arrange
            var film = new Film();
            var filmModel = new FilmModel
            {
                Title = title,
                Country = country,
                Director = director,
                Category = category,
                Release = release,
                Rating = rating
            };

            var mockedRepo = new Mock<IGenericRepository<Film>>();
            mockedRepo.Setup(x => x.Add(film));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.FilmRepository).Returns(mockedRepo.Object);
            //var service = new FilmService(mockUnitOfWork.Object);
            var service = new FilmService();

            //Act
            ServiceResponse response = service.Create(filmModel);

            //Assert
            Assert.False(response.HasSucceeded);
            Assert.NotNull(response.Errors);
        }
    }
}
