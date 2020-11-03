using AutoMapper;
using MediatR;
using SPTest.UserReceiverService.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Common
{
    public abstract class BaseHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        protected readonly UserContext _ctx;
        protected readonly IMapper _mapper;

        protected BaseHandler(UserContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
