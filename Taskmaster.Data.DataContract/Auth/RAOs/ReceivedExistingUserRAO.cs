using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.Data.DataContract.Auth.RAOs
{
    public class ReceivedExistingUserRAO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
