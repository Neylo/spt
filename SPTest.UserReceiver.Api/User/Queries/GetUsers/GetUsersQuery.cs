using MediatR;
using SP.Core.ProcessResult;
using SPTest.UserReceiverService.Api.Common;
using SPTest.UserReceiverService.Api.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.User.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<ProcessResult<PagedList<UserDTO>>>
    {
        public GetUsersQuery(Guid orgId, int pageIndex = 1, int pageSize = 20)
        {
            OrgId = orgId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public Guid OrgId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
