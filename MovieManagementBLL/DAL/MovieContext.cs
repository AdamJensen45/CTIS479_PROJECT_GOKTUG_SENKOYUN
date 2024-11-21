using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBLL.DAL
{
    public class MovieContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);
        }
    }
}
