using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Services.Interfaces;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeRepository repository, IEmployeeService employeeService)
        {
            _repository = repository;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees <see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public GetEmployeesResponse GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="lastName">Last name</param>
        /// <param name="firstName">First name</param>
        /// <param name="middleName">Middle name</param>
        /// <param name="yearOfBirth">Year of birth</param>
        /// <param name="monthOfBirth">Month of birth</param>
        /// <param name="dayOfBirth">Day of birth</param>
        /// <returns></returns>
        [HttpPut]
        public void NewEmployee(NewEmployeeRequest request)
        {
            _employeeService.NewEmployee(request);
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>true on success</returns>
        [HttpDelete]
        public bool DeleteEmployee(Guid id)
        {
            return _repository.DeleteEmployee(id);
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="lastName">Last name</param>
        /// <param name="firstName">First name</param>
        /// <param name="middleName">Middle name</param>
        /// <param name="yearOfBirth">Year of birth</param>
        /// <param name="monthOfBirth">Month of birth</param>
        /// <param name="dayOfBirth">Day of birth</param>
        /// <returns></returns>
        [HttpPost]
        public void UpdateEmployee(UpdateEmployeeRequest request)
        {
            _employeeService.UpdateEmployee(request);
        }
    }
}
