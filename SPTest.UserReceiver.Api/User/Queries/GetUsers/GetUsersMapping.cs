using AutoMapper;
using SPTest.UserReceiverService.Api.Entities;
using SPTest.UserReceiverService.Api.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.User.Queries.GetUsers
{
    public class GetUsersMapping : Profile
    {
        public GetUsersMapping()
        {
            CreateMap<UserEntity, UserDTO>()
                .ForMember(x => x.Organization, src => src.MapFrom(s => s.Organization));
        }
    }
}
