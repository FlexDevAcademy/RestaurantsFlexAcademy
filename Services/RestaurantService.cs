using Microsoft.EntityFrameworkCore;
using RestaurantsFlexDevAcademy.Data;
using RestaurantsFlexDevAcademy.Models;

namespace RestaurantsFlexDevAcademy.Services
{
    public class RestaurantService : IRestaurantService
    {
        List<Restaurant> restaurants;
        private readonly RestaurantContext _context;

        public RestaurantService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.Restaurants.OrderBy(r => r.Name).ToListAsync();
        }

        public async void Add(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);

            if(_context.Restaurants.Count() == 0)
            {
                restaurant.Id = 1;
            }

            //restaurant.Id = _context.Restaurants.Max(r => r.Id) + 1;
            
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> Get(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async void Delete(int id)
        {
            var restaurant = await Get(id);

            if(restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }

        public async void Update(Restaurant restaurant)
        {
            var existingRestaurant =  await Get(restaurant.Id);

            if(existingRestaurant != null)
            {
                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Cuisine = restaurant.Cuisine;
                await _context.SaveChangesAsync();
            }
        }
    }
}
