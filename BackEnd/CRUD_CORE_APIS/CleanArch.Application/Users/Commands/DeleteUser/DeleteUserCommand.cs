using CleanArch.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }


    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IDbContext _context;
        public DeleteUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.User.Where(u => u.Id == request.UserId && !u.IsDeleted).FirstOrDefault();
                if (user == null)
                    return 0;

                user.IsDeleted = true;
                //_context.User.Update(user);
                var success = await _context.SaveChangesAsync(cancellationToken);
                return success;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}
