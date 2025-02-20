using Microsoft.EntityFrameworkCore;

namespace Mission06_Matley.Models
{
    public class MovieFormContext : DbContext
    {

        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
            
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}