using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models;

namespace WebApi.DataAccess
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
    }
}
