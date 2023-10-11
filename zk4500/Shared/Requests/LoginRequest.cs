using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class LoginRequest : Request
    {
        public int UserId { get; set; }
        


    }
}
