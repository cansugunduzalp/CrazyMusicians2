using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrazyMusicians.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Musician> Musicians { get; set; }
    }
}