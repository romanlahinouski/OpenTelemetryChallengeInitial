namespace RestaurantManagement.Domain.Restaurants.Addresses
{
    public class Address
    {
        public int Id { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Country { get; private set; }

        private Address(string city, string street, string country) 
        {
            City = city;
            Street = street;
            Country = country;
        }

        public static Address CreateAddress(string city, string street, string country)
        {
            return new Address(city, street, country);
        }

    }
}