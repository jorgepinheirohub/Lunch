using Lunch.Interfaces;
using Lunch.Mappers;
using Lunch.Models;
using Lunch.Repositories;

namespace Lunch.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<RestaurantModel> CreateRestaurant(RestaurantModel restaurantModel)
        {
            var restaurant = await _restaurantRepository.CreateRestaurant(RestaurantMapper.CreateOrUpdateRestaurantMap(restaurantModel));
            return RestaurantMapper.GetRestaurantMap(restaurant);
        }

        public async Task<RestaurantModel?> GetRestaurantById(Guid restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantId);

            if (restaurant == null)
                return null;

            return RestaurantMapper.GetRestaurantMap(restaurant);
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.GetRestaurants();

            return RestaurantMapper.GetRestaurantsMap(restaurants);
        }

        public async Task<RestaurantModel?> UpdateRestaurant(RestaurantModel restaurantModel)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantModel.Id);

            if (restaurant == null)
                return null;

            await _restaurantRepository.UpdateRestaurant(RestaurantMapper.CreateOrUpdateRestaurantMap(restaurantModel));

            return restaurantModel;
        }

        public async Task<bool> DeleteRestaurant(Guid restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantId);

            if (restaurant == null)
                return false;

            await _restaurantRepository.DeleteRestaurant(restaurant);

            return true;
        }
    }
}