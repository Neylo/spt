using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Common
{
    public interface IEntity<T> where T:struct
    {
        T Id { get; set; }
    }
}
