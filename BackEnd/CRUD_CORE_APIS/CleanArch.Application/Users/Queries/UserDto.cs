using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Users.Queries
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public AddressDto UserAddress { get; set; }
    }
}
