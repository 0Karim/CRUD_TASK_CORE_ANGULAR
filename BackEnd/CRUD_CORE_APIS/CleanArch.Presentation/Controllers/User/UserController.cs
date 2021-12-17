using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Models;
using CleanArch.Application.Users.Commands.CreateUser;
using CleanArch.Application.Users.Commands.DeleteUser;
using CleanArch.Application.Users.Commands.UpdateUser;
using CleanArch.Application.Users.Queries;
using CleanArch.Presentation.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Presentation.Controllers.User
{
    public class UserController : ApiController
    {

        [HttpPost(ApiRoutes.User.UserApi.CreateUser + "/CreateUsers")]
        public async Task<ActionResult<ResponseResult>> CreateUser(CreateUserCommand command)
        {
            if (command == null)
                return BadRequest();

            var success = await Mediator.Send(command);
            return Ok(new ResponseResult((success == 1 ? true : false), new string[] { }, (success == 1 ? "Created Successfully" : "Error in create")));
        }

        [HttpPut(ApiRoutes.User.UserApi.UpdateUser + "UpdateUsers")]
        public async Task<ActionResult<ResponseResult>> UpdateUser(UpdateUserCommand command)
        {
            if (command == null)
                return BadRequest();

            var success = await Mediator.Send(command);
            return Ok(new ResponseResult((success == 1 ? true : false), new string[] { }, (success == 1 ? "Updated Successfully" : "Error in update")));
        }

        [HttpPost(ApiRoutes.User.UserApi.GetAllUser + "/GetAllUsers")]
        public async Task<ActionResult<UsersViewModel>> GetAllUsers(GetAllUsersQuery query)
        {
            if (query == null)
                return BadRequest();

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(ApiRoutes.User.UserApi.DeleteUser + "/DeleteUsers")]
        public async Task<ActionResult<ResponseResult>> DeleteUser(DeleteUserCommand command)
        {
            if (command == null)
                return BadRequest();

            var success = await Mediator.Send(command);
            return Ok(new ResponseResult((success == 1 ? true : false), new string[] { }, (success == 1 ? "Deleted Successfully" : "Error in delete")));
        }
    }
}
