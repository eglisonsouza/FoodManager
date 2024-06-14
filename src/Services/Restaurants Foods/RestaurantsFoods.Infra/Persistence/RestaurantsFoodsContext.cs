using Microsoft.EntityFrameworkCore;
using RestaurantsFoods.Domain.Entities;

namespace RestaurantsFoods.Infra.Persistence
{
    public class RestaurantsFoodsContext : DbContext
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
    }
}
