using Lunch.Entities;
using Lunch.Models;

namespace Lunch.Mappers
{
    public class RestaurantMapper
    {
        public static RestaurantModel GetRestaurantMap(Restaurant restaurant)
        {
            return new RestaurantModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
            };
        }

        public static ICollection<RestaurantModel> GetRestaurantsMap(IEnumerable<Restaurant> restaurants)
        {
            ICollection<RestaurantModel> restaurantList = new List<RestaurantModel>();

            foreach (var restaurant in restaurants)
            {
                restaurantList.Add(new RestaurantModel()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Location = restaurant.Location,
                });
            }

            return restaurantList;
        }

        public static Restaurant CreateOrUpdateRestaurantMap(RestaurantModel restaurantModel)
        {
            return new Restaurant()
            {
                Name = restaurantModel.Name,
                Location = restaurantModel.Location,
            };
        }
    }
}