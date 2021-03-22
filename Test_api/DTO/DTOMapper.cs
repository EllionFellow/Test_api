using AutoMapper.Configuration;
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


            CreateMap<NewEmployeeRequest, DbEmployee>();

            CreateMap<UpdateEmployeeRequest, DbEmployee>()
                .ReverseMap();

            CreateMap<Employee, GetEmployeeResponse>();
            #endregion

            #region Position
            CreateMap<DbPosition, Position>()
                .ReverseMap();

            CreateMap<NewPositionRequest, DbPosition>()
                .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<UpdatePositionRequest, DbPosition>()
                .ReverseMap();

            CreateMap<DbPosition, GetPositionResponse>();
            #endregion

            #region EmployeePosition
            CreateMap<DbEmployeePosition, EmployeePosition>()
                .ReverseMap();

            CreateMap<NewEmployeePositionRequest, EmployeePosition>();

            CreateMap<DeleteEmployeePositionRequest, EmployeePosition>();
            #endregion

        }
    }
}
