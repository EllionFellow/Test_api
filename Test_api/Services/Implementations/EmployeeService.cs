using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Services.Interfaces;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IEmployeeService
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <inheritdoc/>
        public GetEmployeesResponse GetEmployees(GetEmployeesRequest request)
        {
            var response = _employeeRepository.GetEmployees();
            return new GetEmployeesResponse(response);
        }
    }
}
