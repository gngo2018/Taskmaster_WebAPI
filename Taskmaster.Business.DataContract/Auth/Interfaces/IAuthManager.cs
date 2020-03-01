using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskmaster.Business.DataContract.Auth.DTOs;

namespace Taskmaster.Business.DataContract.Auth.Interfaces
{
    public interface IAuthManager
    {
        Task<ReceivedExistingUserDTO> RegisterUser(RegisterUserDTO userDTO);
        Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO userDTO);
        Task<bool> UserExists(string user);
    }
}
