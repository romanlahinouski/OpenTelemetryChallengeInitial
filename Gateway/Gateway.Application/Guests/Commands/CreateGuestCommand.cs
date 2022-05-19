using System;
using MediatR;

namespace Gateway.Application.Guests.Commands
{
    public class CreateGuestCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public CreateGuestCommand(string phoneNumber,
            string firstName,
            string lastName,
            string email,
            string dateofBirth = default)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateofBirth;
        }
    }
}
