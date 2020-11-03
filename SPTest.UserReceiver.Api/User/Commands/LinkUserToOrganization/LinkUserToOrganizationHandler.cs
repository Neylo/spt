using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using SP.Core.ProcessResult;
using SP.EventBus.Events;
using SPTest.UserReceiverService.Api.Common;
using SPTest.UserReceiverService.Api.Entities;
using SPTest.UserReceiverService.Api.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class LinkUserToOrganizationHandler : BaseHandler<LinkUserToOrganizationCommand, ProcessResult<bool>>
    {
        public LinkUserToOrganizationHandler(UserContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override async Task<ProcessResult<bool>> Handle(LinkUserToOrganizationCommand request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<bool>();
            try
            {
                var user = _ctx.Users.FirstOrDefault(x => x.Id == request.UserId);
                if(user == null)
                {
                    result.AddError("User not exist");
                    return result;
                }

                var org = _ctx.Organizations.FirstOrDefault(x => x.Id == request.OrganizationId);
                if(org == null)
                {
                    result.AddError("OrgNotExist");
                    return result;
                }

                user.OrganizationId = request.OrganizationId;

                _ctx.Users.Update(user);

                var saveSucces = await _ctx.SaveChangesAsync() == 1;
                if (saveSucces)
                    result.Result = true;
                else
                    result.AddError(@"Save failed ¯\_(ツ)_/¯");

                return result;
            }
            catch(Exception ex)
            {
                result.AddError(ex.Message);
                return result;
            }

        }
    }
}
