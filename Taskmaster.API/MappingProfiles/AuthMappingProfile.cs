using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskmaster.API.DataContract.Auth;
using Taskmaster.Business.DataContract.Auth.DTOs;
using Taskmaster.Data.DataContract.Auth.RAOs;
using Taskmaster.Data.Entities;

namespace Taskmaster.API.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            // Registration Oriented
            CreateMap<RegisterUserRequest, RegisterUserDTO>();
            CreateMap<RegisterUserDTO, RegisterUserRAO>();
            CreateMap<RegisterUserRAO, UserEntity>();
            CreateMap<LoginUserRequest, QueryForExistingUserDTO>();

            // Login Oriented
            CreateMap<QueryForExistingUserDTO, QueryForExistingUserRAO>();
            CreateMap<QueryForExistingUserRAO, UserEntity>();
            CreateMap<UserEntity, ReceivedExistingUserRAO>();
            CreateMap<ReceivedExistingUserRAO, ReceivedExistingUserDTO>();
            CreateMap<ReceivedExistingUserDTO, ReceivedExistingUserResponse>();
            CreateMap<LoginUserRequest, ReceivedExistingUserResponse>();

            // Authorization Check Oriented
            CreateMap<RegisterUserRAO, QueryForExistingUserRAO>();

        }
    }
}
