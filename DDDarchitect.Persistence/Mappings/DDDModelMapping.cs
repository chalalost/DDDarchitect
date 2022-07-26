using DDDarchitect.Domain.DomainModel.EventDomainModel;
using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using DDDarchitect.Persistence.ValueObjectConverters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Persistence.Mappings
{
    public static class DDDModelMapping
    {
        public static ModelBuilder EventCatalogModelMap(this ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Event>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<EventId>());

            modelBuilder
            .Entity<Event>()
            .Property(o => o.CategoryId)
            .HasConversion(new SingleValueObjectIdentityValueConverter<CategoryId>());

            modelBuilder
            .Entity<Category>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<CategoryId>());

            modelBuilder
                .Entity<Event>()
                .HasOne<Category>()
                .WithMany();

            return modelBuilder;
        }
    }
}
