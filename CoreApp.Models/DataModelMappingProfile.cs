﻿using AutoMapper;
using M = CoreApp.Models.Models;
using DTO = CoreApp.Models.DataTransfer;
using VM = CoreApp.Models.ViewModels;

namespace CoreApp.Models
{
    public class DataModelMappingProfile : Profile
    {
        public DataModelMappingProfile()
        {
            #region ModelToDTo

            CreateMap<DTO.Employee, M.Employee>();

            #endregion

            #region DToToViewModel

            CreateMap<VM.EmployeeViewModel, DTO.Employee>().ReverseMap();
            
            #endregion
        }
    }
}
