using System;
using System.Collections.Generic;
using System.Text;

namespace SP.EventBus.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
