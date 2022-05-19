using NUnit.Framework;
using Gateway.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using Gateway.Infrastructure.Restaurants;
using Gateway.Application.Restaurants;

namespace Gateway.Tests
{
    public class RestaurantFakeRepository_Tests
    {
        [Test]
        public void GetRestaurantsBySpecificationShouldReturnRestaurants()
        {
            ////Arrange
            //IRestaurantRepository restaurantFakeRepository = new RestaurantFakeRepository();
            //Specification<Restaurant> specification = new IdentitySpecification<Restaurant>();
            ////Act
            //var restaurants = restaurantFakeRepository.GetRestaurantBySpecificationAsync(specification);
            ////Assert
            //Assert.AreEqual(restaurantFakeRepository.GetAll().Count, restaurants.Count);

        }
    }
}
