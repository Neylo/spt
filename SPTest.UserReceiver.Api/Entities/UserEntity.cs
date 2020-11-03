using SPTest.UserReceiverService.Api.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Entities
{
    public class UserEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid? OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public OrganizationEntity Organization { get; set; }
    }
}
