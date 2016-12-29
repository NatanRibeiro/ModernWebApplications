﻿using ModernWebStore.Domain.Commands.UserCommands;
using ModernWebStore.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;

        public UserController(IUserApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                email: (string)body.email,
                password: (string)body.password,
                isAdmin: (bool)body.isAdmin
                );

            var user = _service.Register(command);

            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpGet]
        [Route("api/users")]
        [Authorize]
        public string Test()
        {
            return User.Identity.Name;
        }
    }
}