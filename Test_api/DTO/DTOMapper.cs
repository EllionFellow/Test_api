using AutoMapper.Configuration;
using Test_api.DO;

namespace Test_api.DTO
{
    public class DtoMapper : MapperConfigurationExpression
    {
        /// <summary>
        /// Mapping rules
        /// </summary>
        public DtoMapper()
        {
            #region Users
            CreateMap<Employee, DBEmployee>()
                .ReverseMap();
            #endregion
        }
    }
}
