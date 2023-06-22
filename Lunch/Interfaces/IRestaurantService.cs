using Lunch.Models;

namespace Lunch.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantModel>> GetRestaurants();

        Task<RestaurantModel?> GetRestaurantById(Guid restaurantId);

        Task<RestaurantModel> CreateRestaurant(RestaurantModel restaurantModel);

        Task<RestaurantModel?> UpdateRestaurant(RestaurantModel restaurantModel);

        Task<bool> DeleteRestaurant(Guid restaurantId);
    }
}