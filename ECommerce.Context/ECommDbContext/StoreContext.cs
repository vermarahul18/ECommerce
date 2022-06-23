using ECommerce.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Context.ECommDbContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.;Initial Catalog=ECommerceDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*var modifiedEntries = ChangeTracker.Entries()
                                  .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

                var createdProperties = entityType.FindProperty("SysCreateDateTimeUtc");
                var primaryKey = entityType.FindProperty("Id");

                if (entry.State == EntityState.Added && createdProperties != null)
                {
                    entry.Property("SysCreateDateTimeUtc").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added && primaryKey != null)
                {
                    entry.Property("Id").CurrentValue = Guid.NewGuid();
                }
            }*/
        }



        public DbSet<Product> Products { get; set; }
    }
}
