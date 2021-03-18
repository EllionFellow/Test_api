using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_api.DTO.Request;
using Test_api.DTO.Response;

namespace Test_api.Services.Interfaces
{
    /// <summary>
    /// Interface for employee service
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="request"><see cref="GetEmployeesRequest"/></param>
        /// <returns></returns>
        public GetEmployeesResponse GetEmployees(GetEmployeesRequest request);
    }
}
