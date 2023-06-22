﻿namespace Lunch.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}