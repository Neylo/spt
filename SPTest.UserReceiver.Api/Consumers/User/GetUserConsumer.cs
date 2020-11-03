using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using SP.EventBus.Events;
using SP.EventBus.Models;
using SPTest.UserProcessingService.Api.User.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Consumers.User
{
    public class GetUserConsumer : IConsumer<UserCreateMessage>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetUserConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<UserCreateMessage> context)
        {
            Log.Information($"User request received UserID:{context.Message.User.Id}, sended at {context.Message.CreatedDate}");
            var result = _mediator.Send(_mapper.Map<CreateUserCommand>(context.Message.User));
            await context.RespondAsync(result);
        }
    }
}
