using Microservice.Framework.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Persistence
{
    public class DDDarchitectDbContextProvider : IDbContextProvider<DDDarchitectDbContext>, IDisposable
    {
        private readonly DbContextOptions<DDDarchitectDbContext> _options;

        public DDDarchitectDbContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<DDDarchitectDbContext>()
                .UseSqlServer(configuration["DataConnection:Database"])
                .Options;
        }

        public DDDarchitectDbContext CreateContext()
        {
            return new DDDarchitectDbContext(_options);
        }

        public void Dispose()
        {
        }
    }
}
