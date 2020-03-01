using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taskmaster.Data.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }

    }
}
