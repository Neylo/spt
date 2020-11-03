using SP.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP.EventBus.Events
{
    public class UserCreateMessage : IUserCreateMessage
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
