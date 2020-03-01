using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.API.DataContract.Auth
{
    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
