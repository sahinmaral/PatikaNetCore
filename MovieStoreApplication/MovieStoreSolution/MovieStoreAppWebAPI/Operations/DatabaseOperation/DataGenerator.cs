using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MovieStoreAppWebAPI.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MovieStoreAppWebAPI.Operations.DatabaseOperation
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreInMemoryDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieStoreInMemoryDbContext>>()))
            {

                if (context.Films.Any())
                {
                    return;
                }

                if (context.Genres.Any())
                {
                    return;
                }

                if (context.Directors.Any())
                {
                    return;
                }

                if (context.Players.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre() { Name = "Action" },
                    new Genre()
                    { Name = "Adventure" },
                    new Genre()
                    { Name = "Comedy" },
                    new Genre()
                    { Name = "Science fiction" }
                );

                context.Directors.AddRange(
                new Director() { Name = "Christopher", Surname = "Nolan" },
                new Director() { Name = "Quentin", Surname = "Tarantino" },
                new Director() { Name = "Michael", Surname = "Bay" },
                new Director() { Name = "Martin", Surname = "Scorsese" }
                );

                context.Players.AddRange(
                    new Player() { Name = "Elizabeth", Surname = "Olsen" },
                    new Player() { Name = "Scarlett", Surname = "Johansson" },
                    new Player() { Name = "Tom", Surname = "Cruise" },
                    new Player() { Name = "Jim", Surname = "Carrey" },
                    new Player() { Name = "Will", Surname = "Smith" },
                    new Player() { Name = "Robert Downey", Surname = "Jr." },
                    new Player() { Name = "Johnny", Surname = "Depp" },
                    new Player() { Name = "Brad", Surname = "Pitt" },
                    new Player() { Name = "Angelina", Surname = "Jolie" },
                    new Player() { Name = "Leonardo", Surname = "DiCaprio" },
                    new Player() { Name = "Clint", Surname = "Eastwood" },
                    new Player() { Name = "Hugh", Surname = "Jackman" },
                    new Player() { Name = "Matt", Surname = "Damon" },
                    new Player() { Name = "Elizabeth", Surname = "Debicki" },
                    new Player() { Name = "Robert", Surname = "Pattinson" },
                    new Player() { Name = "John David", Surname = "Washington" },
                    new Player() { Name = "Kenneth", Surname = "Branagh" },
                    new Player() { Name = "Clémence", Surname = "Poésy" },
                    new Player() { Name = "Anne", Surname = "Hathaway" },
                    new Player() { Name = "Jessica", Surname = "Chastain" },
                    new Player() { Name = "Michael", Surname = "Caine" },
                    new Player() { Name = "Matthew", Surname = "McConaughey" }
                        );

                context.Films.AddRange(
                    new Film()
                    {
                        DirectorId = 1,
                        GenreId = 4,
                        Name = "Tenet",
                        Price = 200,
                        PublishedDate = new DateTime(2020, 8, 26),
                        About = "Tenet is a 2020 science fiction action thriller film written and directed by Christopher Nolan, who produced it with Emma Thomas. A co-production between the United Kingdom and United States, it stars John David Washington, Robert Pattinson, Elizabeth Debicki, Dimple Kapadia, Michael Caine, and Kenneth Branagh. The film follows a secret agent who learns to manipulate the flow of time to prevent an attack from the future that threatens to annihilate the present world."
                    },
                    new Film()
                    {
                        DirectorId = 1,
                        GenreId = 4,
                        Name = "Interstellar",
                        Price = 200,
                        PublishedDate = new DateTime(2020, 8, 26),
                        About = ""
                    }
                );

                context.FilmAndPlayerRelations.AddRange(
                    new FilmAndPlayerRelation(){FilmId = 1,PlayerId = 15},
                    new FilmAndPlayerRelation(){FilmId = 1,PlayerId = 16},
                    new FilmAndPlayerRelation(){FilmId = 1,PlayerId = 17},
                    new FilmAndPlayerRelation(){FilmId = 1,PlayerId = 18},
                    new FilmAndPlayerRelation(){FilmId = 1,PlayerId = 19},
                    new FilmAndPlayerRelation(){FilmId = 2,PlayerId = 13},
                    new FilmAndPlayerRelation(){FilmId = 2,PlayerId = 19},
                    new FilmAndPlayerRelation(){FilmId = 2,PlayerId = 20},
                    new FilmAndPlayerRelation(){FilmId = 2,PlayerId = 21},
                    new FilmAndPlayerRelation(){FilmId = 2,PlayerId = 22}
                    );

                context.SaveChanges();
            }
        }


    }
}
