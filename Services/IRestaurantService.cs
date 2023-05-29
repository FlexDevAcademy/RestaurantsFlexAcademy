using RestaurantsFlexDevAcademy.Models;

namespace RestaurantsFlexDevAcademy.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAll();

        Task Add(Restaurant restaurant);

        Task<Restaurant> Get(int id);

        Task Delete(int id);

        Task Update(Restaurant restaurant);
    }
}
