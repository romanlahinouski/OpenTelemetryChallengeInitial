using System;
using RestaurantManagement.Domain.Restaurants.Dishes.Ingredients;

namespace RestaurantManagement.Domain.Restaurants.Dishes.Ingredients
{
    public class DishIngredient
    {

        public int DishIngredientId { get; set; }

        public DishIngredient()
        {
            //ef core only
        }

        public DishIngredient(int id, string name, string unitType, float amount)
        {
            Name = name;
            UnitType = unitType;
            Amount = amount;
            DishIngredientId = id;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string UnitType { get; set; }
        public float Amount { get; set; }


    }
}
