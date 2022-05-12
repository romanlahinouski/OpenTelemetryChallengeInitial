using System.ComponentModel.DataAnnotations;

namespace Gateway.Guests
{
    public class RegisterGuestDto
    {
     
        public string Email { get; set; } 
        public int RestaurantId { get; set; }

    }
}