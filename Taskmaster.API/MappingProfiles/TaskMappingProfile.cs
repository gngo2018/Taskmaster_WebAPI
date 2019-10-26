using System;
using AutoMapper;
using Taskmaster.API.DataContract.Task;
using Taskmaster.Business.DataContract.Task;
using Taskmaster.Data.DataContract.Task;
using Taskmaster.Data.Entities;

namespace Taskmaster.API.MappingProfiles
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            //Post Mapping
            CreateMap<TaskCreateRequest, TaskCreateDTO>();
            CreateMap<TaskCreateDTO, TaskCreateRAO>();
            CreateMap<TaskCreateRAO, TaskDataModel>();

            //Get Mapping
            CreateMap<TaskDataModel, TaskGetListItemRAO>();
            CreateMap<TaskGetListItemRAO, TaskGetListItemDTO>();
            CreateMap<TaskGetListItemDTO, TaskGetListItemResponse>();

            //Put Mapping
            CreateMap<TaskUpdateRequest, TaskUpdateDTO>();
            CreateMap<TaskUpdateDTO, TaskUpdateRAO>();
            CreateMap<TaskUpdateRAO, TaskDataModel>();
        }
    }
}
