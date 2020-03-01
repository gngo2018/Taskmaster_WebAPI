using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.Data.Entities
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
