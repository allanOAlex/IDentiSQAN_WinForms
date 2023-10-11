using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class FetchUserResponse : Response
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        


    }
}
