using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Core.ProcessResult;
using SPTest.UserProcessingService.Api.User.Commands;

namespace SPTest.UserProcessingService.Api.Controllers
{
    public class UserController : BaseController
    {

        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<Guid>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProcessResult<Guid>>> Create(CreateUserCommand command, CancellationToken token)
        {
            return await _mediator.Send(command, token);
        }
    }
}
