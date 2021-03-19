﻿using AutoMapper.Configuration;
using System;
using Test_api.DO;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Entity;

namespace Test_api.DTO
{
    public class DtoMapper : MapperConfigurationExpression
    {
        /// <summary>
        /// Mapping rules
        /// </summary>
        public DtoMapper()
        {
            #region Employee
            CreateMap<DbEmployee, Employee>()
                .ForMember(x => x.Positions, y => y.Ignore());

            CreateMap<Employee, DbEmployee>();

            CreateMap<NewEmployeeRequest, DbEmployee>()
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(src => new DateTime(src.YearOfBirth, src.MonthOfBirth, src.DayOfBirth)));

            CreateMap<UpdateEmployeeRequest, DbEmployee>()
                .ReverseMap();

            CreateMap<Employee, GetEmployeeResponse>();
            #endregion

            #region Position
            CreateMap<NewPositionRequest, DbPosition>()
                .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<UpdatePositionRequest, DbPosition>()
                .ReverseMap();

            CreateMap<DbPosition, GetPositionResponse>();
            #endregion

            #region EmployeePosition
            CreateMap<NewPositionRequest, DbEmployeePosition>();

            CreateMap<DeleteEmployeePositionRequest, DbEmployeePosition>();
            #endregion

        }
    }
}
