using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.API.DataContract.Auth
{
    public class ReceivedExistingUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
