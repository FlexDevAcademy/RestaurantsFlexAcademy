using Microsoft.EntityFrameworkCore;
using RestaurantsFlexDevAcademy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace RestaurantsFlexDevAcademy.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options): base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
