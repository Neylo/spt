using MediatR;
using SP.Core.ProcessResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands
{
    public class CreateUserCommand : IRequest<ProcessResult<Guid>>
    {
        public CreateUserCommand(Guid id, string firstName, string surname, string middleName,string phone, string email)
        {
            Id = id;
            FirstName = firstName;
            SurName = surname;
            MiddleName = middleName;
            Phone = phone;
            Email = email;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
