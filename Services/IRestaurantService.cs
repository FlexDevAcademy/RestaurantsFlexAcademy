using RestaurantsFlexDevAcademy.Models;

namespace RestaurantsFlexDevAcademy.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAll();

        void Add(Restaurant restaurant);

        Task<Restaurant> Get(int id);

        void Delete(int id);

        void Update(Restaurant restaurant);
    }
}
