using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SP.Core.ProcessResult;
using SPTest.UserReceiverService.Api.Common;
using SPTest.UserReceiverService.Api.Infrastructure;
using SPTest.UserReceiverService.Api.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.User.Queries.GetUsers
{
    public class GetUsersHandler : BaseHandler<GetUsersQuery, ProcessResult<PagedList<UserDTO>>>
    {
        public GetUsersHandler(UserContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override async Task<ProcessResult<PagedList<UserDTO>>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<PagedList<UserDTO>>();
            var org = _ctx.Organizations.FirstOrDefault(x => x.Id == query.OrgId);
            if(org == null)
            {
                result.AddError("OrganizationNotExist");
                return result;
            }
                var skip = query.PageIndex * query.PageSize;
                var users = _ctx.Users
                    .Include(x => x.Organization)
                    .Where(x => x.OrganizationId == query.OrgId)
                    .Take(query.PageSize)
                    .Skip(skip)
                    .ToList();
            var totalPages = _ctx.Users.Count() / query.PageSize;

            var dtos = _mapper.Map<List<UserDTO>>(users);
            result.Result = new PagedList<UserDTO>(query.PageIndex, query.PageSize, totalPages, dtos);

            return result;
        }
    }
}
