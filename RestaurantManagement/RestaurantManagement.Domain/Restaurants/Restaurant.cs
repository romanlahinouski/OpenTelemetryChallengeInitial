using RestaurantManagement.Domain.Restaurants.Cuisines;
using System;
using System.Collections.Generic;

namespace RestaurantManagement.Domain.Restaurants
{
    public class Restaurant
    {

        public int RestaurantId { get; private set; }

        public string RestaurantName { get;  private set; }

        public int? Stars { get;  private set; }

        public float Rating { get; private set; }

        public Cuisine Cuisine { get; private set; }


        private List<RestaurantGuest> currentGuests 
            = new List<RestaurantGuest>();

        public string Street { get; private set; }
        public string City { get; private set; }
    
        private  int maxNumberOfGuests;

        public string Description { get;  private set; }


        public Restaurant()
        {
            //Ef core
        }

        private Restaurant(string restaurantName,
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default)
        {
            RestaurantName = restaurantName;
            Cuisine = cuisine;
            City = city;
            Street = street;
            Description = description;

            this.maxNumberOfGuests = maxNumberOfGuests;
                              
        }

        public static Restaurant CreateRestaurant(
            string restaurantName, 
            int maxNumberOfGuests,
            Cuisine cuisine,
            string city,
            string street,
            string description = default)
        {
            return new Restaurant(restaurantName, maxNumberOfGuests, cuisine, city,street, description);
        }

        public int GetMaxNumberOfGuests()
        {
            return maxNumberOfGuests;
        }

        public int GetCurrentNumberOfGuests()
        {
            return currentGuests.Count;
        }      

        public void RegisterGuest(int guestId)
        {
            if (!HasCapacity())
                throw new Exception();

            RestaurantGuest restaurantGuest = new RestaurantGuest(guestId, RestaurantId);

            currentGuests.Add(restaurantGuest);
        }


        private bool HasCapacity()
        {
            if (GetCurrentNumberOfGuests() 
                >= GetMaxNumberOfGuests())            
                return false;

            return true;
        }

        public int GetRemainingCapacity()
        {
            return maxNumberOfGuests - currentGuests.Count;
        }
    }
}
