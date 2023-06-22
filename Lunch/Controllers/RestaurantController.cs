using Lunch.Interfaces;
using Lunch.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lunch.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Route("{restaurantGuid}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] Guid restaurantGuid)
        {
            var restaurant = await _restaurantService.GetRestaurantById(restaurantGuid);

            if (restaurant == null) return NotFound();

            return Ok(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetRestaurants();

            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantModel restaurantModel)
        {
            return Ok(await _restaurantService.CreateRestaurant(restaurantModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantModel restaurantModel)
        {
            var restaurant = await _restaurantService.UpdateRestaurant(restaurantModel);

            if (restaurant == null) return NotFound();

            return Ok(restaurant);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] Guid restaurantId)
        {
            var result = await _restaurantService.DeleteRestaurant(restaurantId);

            if (!result) return NotFound();

            return Ok();
        }
    }
}