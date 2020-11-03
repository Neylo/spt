using MediatR;
using SP.Core.ProcessResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands
{
    public class LinkUserToOrganizationCommand : IRequest<ProcessResult<bool>>
    {
        public LinkUserToOrganizationCommand(Guid userId, Guid orgId)
        {
            UserId = userId;
            OrganizationId = orgId;
        }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
