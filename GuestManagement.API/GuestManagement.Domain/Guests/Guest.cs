using GuestManagement.Domain.Guests.Visits;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuestManagement.Domain.Guests
{

    public class Guest 
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public DateTime DateOfBirth { get; set; }

        //public Address Address { get; private set; }

        [JsonProperty(propertyName: "id")]
        public string GuestId { get; set; }


        public List<Visit> Visits { get; set; }
            = new List<Visit>();

        public Guest()
        {
            //EFCore

            GuestId = Guid.NewGuid().ToString();
        }
        private Guest(string firstName,
         string lastName,
         string email,
         string phoneNumber,
         DateTime dateOfBirth
         ) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }
        public static Guest Create(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            DateTime dateOfBirth
            ) 
        {
            return new Guest(firstName, lastName, email, phoneNumber, dateOfBirth);
        }

        public void AddVisit(Visit visit)
        {
            Visits.Add(visit);
        }

    }
}
