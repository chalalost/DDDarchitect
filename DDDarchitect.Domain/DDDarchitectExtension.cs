using Microservice.Framework.Domain;
using Microservice.Framework.Domain.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Domain
{
    public static class DDDarchitectExtension
    {
        public static Assembly Assembly { get; } = typeof(DDDarchitectExtension).Assembly;

        public static IDomainContainer ConfigureEventCatalogServiceDomain(
            this IServiceCollection services)
        {
            return DomainContainer.New(services)
                .AddDefaults(Assembly);
        }
    }
}
