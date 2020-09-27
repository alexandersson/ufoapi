using Microsoft.EntityFrameworkCore;
using System;
using ufoapi.Data;

namespace ufoapi.Entities
{
    public class SightingContext : DbContext
    {
        public SightingContext(DbContextOptions<SightingContext> options) : base(options)
        {
            
        }
        public DbSet<Sighting> Sightings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sighting.db");
    }

    public class Sighting : IEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }
}
