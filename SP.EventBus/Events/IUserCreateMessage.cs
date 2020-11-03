using SP.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP.EventBus.Events
{
    public interface IUserCreateMessage
    {
        Guid Id { get; set; }
        UserDTO User { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
