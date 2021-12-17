using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Users.Queries
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string GoveName { get; set; }

        public string CityName { get; set; }

        public string BuildingNumber { get; set; }

        public string Street { get; set; }
    }
}
