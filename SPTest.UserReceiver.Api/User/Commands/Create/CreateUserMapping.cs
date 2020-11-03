using AutoMapper;
using SP.EventBus.Models;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class CreateUserMapping : Profile
    {
        public CreateUserMapping()
        {
            CreateMap<UserDTO, CreateUserCommand>();
        }
    }
}
