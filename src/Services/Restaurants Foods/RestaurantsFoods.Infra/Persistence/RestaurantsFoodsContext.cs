using FoodManager.Core.Data;
using FoodManager.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using RestaurantsFoods.Domain.Entities;

namespace RestaurantsFoods.Infra.Persistence
{
    public class RestaurantsFoodsContext : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }

        public RestaurantsFoodsContext(DbContextOptions<RestaurantsFoodsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantsFoodsContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nameof(Entity.CreatedAt)) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(Entity.UpdatedAt)).CurrentValue = DateTime.Now;
                }
            }

            var isSuccess = await base.SaveChangesAsync() > 0;

            return isSuccess;
        }
    }
}
