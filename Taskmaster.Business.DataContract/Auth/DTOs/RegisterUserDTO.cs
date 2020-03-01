using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.Business.DataContract.Auth.DTOs
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
