using System;

namespace GuestManagement.Domain.Guests{

    public class NoGuestPresentInTheSystemException : Exception{

       public NoGuestPresentInTheSystemException(string message) : base(message)
       {
           
       }

    }
}