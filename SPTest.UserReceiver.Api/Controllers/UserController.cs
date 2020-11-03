using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Core.ProcessResult;
using SPTest.UserReceiverService.Api.Common;
using SPTest.UserReceiverService.Api.Controllers;
using SPTest.UserReceiverService.Api.User.DTO;
using SPTest.UserReceiverService.Api.User.Queries.GetUsers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPTest.UserReceiver.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<PagedList<UserDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProcessResult<PagedList<UserDTO>>>> GetByOrganization(GetUsersQuery query, CancellationToken token)
        {
            return await _mediator.Send(query, token);
        }
    }
}
