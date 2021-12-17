using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public int? AddressId { get; set; }

    }


    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDbContext _context;
        public CreateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    MobileNumber = request.MobileNumber,
                    AddressId = request.AddressId,
                    IsDeleted = false,
                    Email = request.Email
                };

                _context.User.Add(user);
                var success = await _context.SaveChangesAsync(cancellationToken);

                int currentUserId = user.Id;

                return success;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
