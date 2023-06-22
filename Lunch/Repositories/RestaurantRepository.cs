using Lunch.Context;
using Lunch.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunch.Repositories
{
    public class RestaurantRepository
    {
        private readonly LunchContext _context;

        public RestaurantRepository(LunchContext lunchContext)
        {
            _context = lunchContext;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _context.Restaurant.ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantById(Guid id)
        {
            return await _context.Restaurant.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Restaurant> CreateRestaurant(Restaurant restaurant)
        {
            await _context.Restaurant.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurant.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}