using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<UsersViewModel>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }


    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersViewModel>
    {
        private readonly IDbContext _context;

        public GetAllUsersQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<UsersViewModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.User
                .Include("UserAddress")
                .Include("UserAddress.Governate")
                .Include("UserAddress.City")
                .Where(u => !u.IsDeleted);

            var count = await query.CountAsync();

            var users = await query
                .Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .ToListAsync();
            var result = MapUsersToViewModels(users);
            result.TotalCount = count;
            return MapUsersToViewModels(users);
        }

        private UsersViewModel MapUsersToViewModels(List<User> usersList)
        {
            var usersVm = new UsersViewModel();
            foreach(var user in usersList)
            {
                usersVm.UserList.Add(
                    new UserDto
                    {
                        BirthDate = user.BirthDate,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        MobileNumber = user.MobileNumber,
                        UserAddress = MapAddressToDto(user.UserAddress)
                    });
            }
            return usersVm;
        }

        private AddressDto MapAddressToDto(AddressInfo addressInfo)
        {
            return new AddressDto
            {
                BuildingNumber = addressInfo.BuildingNumber,
                CityName = addressInfo.City.CityName,
                GoveName = addressInfo.Governate.GovName,
                Street = addressInfo.Street
            };
        }
    }

}
