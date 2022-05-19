using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuestManagement.Application.Guests.Commands
{
    public class CreateGuestCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }      
        public DateTime DateOfBirth { get; set; }

        public CreateGuestCommand(string phoneNumber,
            string firstName,
            string lastName,
            string email,
            DateTime dateOfBirth = default)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}
