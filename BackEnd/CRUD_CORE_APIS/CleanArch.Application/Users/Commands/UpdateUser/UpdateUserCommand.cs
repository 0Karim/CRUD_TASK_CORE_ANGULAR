using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.UpdateUser
{

    public class UpdateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public int? AddressId { get; set; }

    }


    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IDbContext _context;
        public UpdateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.User.Where(u => u.Id == request.UserId && !u.IsDeleted).FirstOrDefault();
                if (user == null)
                    return 0;

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.BirthDate = request.BirthDate;
                user.MiddleName = request.MiddleName;
                user.MobileNumber = request.MobileNumber;
                user.Email = request.Email;
                user.AddressId = request.AddressId;


                //_context.User.Update(user);
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
