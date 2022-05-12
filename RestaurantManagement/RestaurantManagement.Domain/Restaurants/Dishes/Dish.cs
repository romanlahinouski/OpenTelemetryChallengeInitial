using RestaurantManagement.Domain.Restaurants.Dishes.Ingredients;
using System;
using System.Collections.Generic;

namespace RestaurantManagement.Domain.Restaurants.Dishes
{
    public class Dish
    {


        public decimal Price { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        public Dish()
        {
            //ef core only
        }

        private Dish(int id,
            string name,
            List<DishIngredient> ingredients,
            decimal price,
            string description = default)
        {
            Name = name;
            Price = price;
            Description = description;
            Id = id;

            this.ingredients = ingredients;

        }

        public static Dish CreateDish(int id,
            string name,
            List<DishIngredient> ingredients,
            decimal price)
        {
            return new Dish(id, name, ingredients, price);
        }

        private List<DishIngredient> ingredients
            = new List<DishIngredient>();


        public decimal GetPrice()
        {
            return Price;
        }

    }
}
