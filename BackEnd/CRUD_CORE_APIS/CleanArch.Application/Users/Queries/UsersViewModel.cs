using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Users.Queries
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
            UserList = new List<UserDto>();
        }

        public IList<UserDto> UserList { get; set; }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
