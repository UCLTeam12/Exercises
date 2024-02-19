using Microsoft.EntityFrameworkCore;

namespace ASP_Web_App.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_Web_App.Models.Movie> Movie { get; set; } = default!;
    }
}
