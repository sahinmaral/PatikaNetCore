using Microsoft.EntityFrameworkCore;
using MovieStoreAppWebAPI.Entities;

namespace MovieStoreAppWebAPI.Operations.DatabaseOperation
{
    public class MovieStoreInMemoryDbContext:DbContext,IMovieStoreDbContext
    {
        public MovieStoreInMemoryDbContext(DbContextOptions<MovieStoreInMemoryDbContext> options):base(options)
        {
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film>  Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FilmAndPlayerRelation> FilmAndPlayerRelations { get; set; }
    }
}
