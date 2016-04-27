namespace CapacitacionMVC.Data.Migrations
{
    using CapacitacionMVC.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CapacitacionMVC.Data.DomainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CapacitacionMVC.Data.DomainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            var dummyPlot = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var horror = context.Genres.FirstOrDefault(p=>p.Name == "Horror") ?? new Genre() { Name = "Horror" };
            var drama = context.Genres.FirstOrDefault(p => p.Name == "Drama") ?? new Genre() { Name = "Drama" };
            var sciFi = context.Genres.FirstOrDefault(p => p.Name == "Science Fiction") ?? new Genre() { Name = "Science Fiction" };
            var action = context.Genres.FirstOrDefault(p => p.Name == "Action") ?? new Genre() { Name = "Action" };
            var documentary = context.Genres.FirstOrDefault(p => p.Name == "Documentary") ?? new Genre() { Name = "Documentary" };

            context.Movies.AddOrUpdate(
              p => p.Name,
              new Movie { Name = "Star Wars", Genre = sciFi, GenreId= sciFi.Id, ReleaseDate = new DateTime(2010, 1, 15), Plot = dummyPlot, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTU4NTczODkwM15BMl5BanBnXkFtZTcwMzEyMTIyMw@@._V1_UX182_CR0,0,182,268_AL_.jpg", Runtime = 250 },
              new Movie { Name = "Scream", Genre = horror, GenreId = horror.Id, ReleaseDate = new DateTime(2010, 2, 15), Plot = dummyPlot, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjA2NjU5MTg5OF5BMl5BanBnXkFtZTgwOTkyMzQxMDE@._V1_UX182_CR0,0,182,268_AL_.jpg", Runtime = 100 },
              new Movie { Name = "Iron Man", Genre = action, GenreId = action.Id, ReleaseDate = new DateTime(2010, 4, 15), Plot = dummyPlot, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg", Runtime = 200 },
              new Movie { Name = "Forrest Gump", Genre = drama, GenreId = drama.Id, ReleaseDate = new DateTime(2010, 5, 15), Plot = dummyPlot, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTI1Nzk1MzQwMV5BMl5BanBnXkFtZTYwODkxOTA5._V1_UY268_CR2,0,182,268_AL_.jpg", Runtime = 260 },
              new Movie { Name = "Cartel Land", Genre = documentary, GenreId = documentary.Id, ReleaseDate = new DateTime(2010, 6, 15), Plot = dummyPlot, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjE1MzI2MzcxOV5BMl5BanBnXkFtZTgwNTE2Mjk4NTE@._V1_UX182_CR0,0,182,268_AL_.jpg", Runtime = 210 }
            );
        }
    }
}
