using System;
using System.Collections.Generic;
using System.Text;

namespace GuestManagement.Domain.Guests.Visits
{
    public class Visit
    {     
        public int VisitId { get; }
        public int RestaurantId { get; }
        public DateTime TimeStart { get; }

        public DateTime TimeEnd { get; }
        public decimal Paycheck { get; }

        public bool IsActive { get; set; }

        public Visit()
        {
            //ef core
        }

        private Visit(int restaurantId, DateTime timeStart, decimal paycheck)
        {
            RestaurantId = restaurantId;
            TimeStart = timeStart;
            Paycheck = paycheck;
            IsActive = true;
        }


        private Visit(int id, int restaurantId)
        {
            VisitId = id;
            RestaurantId = restaurantId;
            IsActive = true;
        }


        public static Visit CreateVisit(int restaurantId, DateTime duration, decimal paycheck)
        {
            return new Visit(restaurantId, duration, paycheck);
        }

        public static Visit CreateVisit(int id,
            int restaurantId)

        {
            return new Visit(id, restaurantId);
        }    
    }
}
