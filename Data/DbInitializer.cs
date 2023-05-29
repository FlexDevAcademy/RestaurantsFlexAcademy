using Microsoft.EntityFrameworkCore;
using RestaurantsFlexDevAcademy.Models;

namespace RestaurantsFlexDevAcademy.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(RestaurantContext context) {
        context.Database.EnsureCreated();

            if(context.Restaurants.Any())
            {
                return;
            }

            var restaurants = new Restaurant[]
            {
                new Restaurant { Id = 1, Name = "Forni Rossi", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Petit Paris", Cuisine= CuisineType.French},
                new Restaurant { Id = 3, Name = "The Mexican", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 4, Name = "Chmeli Suneli", Cuisine = CuisineType.Gregorian}
            };

            await context.Restaurants.AddRangeAsync(restaurants);
            await context.SaveChangesAsync();
        }
    }
}
