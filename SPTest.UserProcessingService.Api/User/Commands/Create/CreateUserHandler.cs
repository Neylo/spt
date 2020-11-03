using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using SP.Core.ProcessResult;
using SP.EventBus.Events;
using SP.EventBus.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ProcessResult<Guid>>
    {
        private readonly IPublishEndpoint _eventBus;
        private readonly IMapper _mapper;

        public CreateUserHandler(IPublishEndpoint eventBus, IMapper mapper)
        {
            _eventBus = eventBus;
            _mapper = mapper;
        }
        public async Task<ProcessResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            
            var result = new ProcessResult<Guid>();
            var user = _mapper.Map<UserDTO>(request);
            try
            {
                user.Id = Guid.NewGuid();
                var messageId = Guid.NewGuid();
                await _eventBus.Publish<IUserCreateMessage>(new UserCreateMessage
                {
                    Id = messageId,
                    User = user,
                    CreatedDate = DateTime.Now
                });
                
                result.Result = user.Id;

                Log.Information($"{nameof(UserCreateMessage)} sended to rmq with Id {messageId}");

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
