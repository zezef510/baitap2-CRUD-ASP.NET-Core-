using baitap2_CRUD_.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Movie { get; set; }
    }
}