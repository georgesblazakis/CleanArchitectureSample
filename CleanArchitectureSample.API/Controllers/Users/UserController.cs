using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Users.Commands.CreateUser;
using CleanArchitectureSample.Application.Users.Commands.DeleteUser;
using CleanArchitectureSample.Application.Users.Commands.UpdateUser;
using CleanArchitectureSample.Application.Users.Queries.GetUserDetail;
using CleanArchitectureSample.Application.Users.Queries.GetUsersList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.API.Controllers.Users
{
    public class UserController : BaseController
    {
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<GetUsersListViewModel>> GetAll()
        {
            var vm = await Mediator.Send(new GetUsersListQuery());
            return Ok(vm);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDetailViewModel>> Get(int id)
        {
            var vm = await Mediator.Send(new GetUserDetailQuery { Id = id });
            return Ok(vm);
        }

        // POST: api/User
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }


    }
}
