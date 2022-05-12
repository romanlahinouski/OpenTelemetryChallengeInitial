using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Application.Orders
{
    public class UserNotRegisterForAVisitException : Exception
    {
        public int GuestId { get; set; }

    
        public UserNotRegisterForAVisitException(string message,int guestId) : base(message)
        {
            GuestId = guestId;
        }
      

    }
}
