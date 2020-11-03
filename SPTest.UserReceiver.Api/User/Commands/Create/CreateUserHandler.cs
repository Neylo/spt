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
using System.Threading;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class CreateUserHandler : BaseHandler<CreateUserCommand, ProcessResult<Guid>>
    {
        public CreateUserHandler(UserContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override async Task<ProcessResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<Guid>();
            try
            {
                var user = _mapper.Map<UserEntity>(request);
                _ctx.Users.Add(user);
                var saveSucces = await _ctx.SaveChangesAsync() == 1;
                if (saveSucces)
                    result.Result = user.Id;
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
