﻿namespace Lunch.Models
{
    public class RestaurantModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}