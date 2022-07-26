using DDDarchitect.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Persistence
{
    public class DDDarchitectDbContext : DbContext
    {
        public DDDarchitectDbContext(DbContextOptions<DDDarchitectDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EventCatalogModelMap();
        }
    }
}
