using System;
namespace RestaurantManagement.Domain.Restaurants.Dishes.Ingredients
{
    public class IngredientAmount
    {
        public UnitType UnitType { get; set; }
        public float Amount { get; set; }

        public IngredientAmount(UnitType unitType,float amount)
        {
            UnitType = unitType;
            Amount = amount;
        }
        
     
    }
}
