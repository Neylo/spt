using SPTest.UserReceiverService.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Infrastructure
{
    public class UserContextSeed
    {
        public async Task SeedAsync(UserContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
            }
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(GetOrganizations());
            }
        }

        private IEnumerable<UserEntity> GetUsers()
        {
            return new List<UserEntity>()
            {
                new UserEntity(){ Id = new Guid(),Email = "test1@test.test", FirstName = "Igor", SurName = "Igorev",MiddleName = "Igorevich",Phone = "+79992334530"},
                new UserEntity(){ Id = new Guid(),Email = "test2@test.test", FirstName = "Vanya", SurName = "Ivanovich",MiddleName = "Ivanna",Phone = "+79992334533"},
                new UserEntity(){ Id = new Guid(),Email = "test3@test.test", FirstName = "John", SurName = "Doe",Phone = "+79992334545"},
            };
        }

        private IEnumerable<OrganizationEntity> GetOrganizations()
        {
            return new List<OrganizationEntity>()
            {
                new OrganizationEntity(){ Id = new Guid(),Name= "MCHS"},
                new OrganizationEntity(){ Id = new Guid(),Name= "FSB"},
                new OrganizationEntity(){ Id = new Guid(),Name= "FSO"}
            };
        }
    }
}
