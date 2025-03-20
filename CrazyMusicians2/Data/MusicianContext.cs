using CrazyMusiciansAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrazyMusiciansAPI.Data
{
    public class MusicianContext : DbContext
    {
        public MusicianContext(DbContextOptions<MusicianContext> options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }
    }
}