using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.Data.DataContract.Auth.RAOs
{
    public class RegisterUserRAO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
