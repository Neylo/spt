using AutoMapper;
using SPTest.UserProcessingService.Api.User.Commands;
using SPTest.UserReceiverService.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Utils.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, User.DTO.UserDTO>()
               .ForMember(x => x.Organization, src => src.MapFrom(s => s.Organization));

            CreateMap<SP.EventBus.Models.UserDTO, CreateUserCommand>();
        }
    }
}
