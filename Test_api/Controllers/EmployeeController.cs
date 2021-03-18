using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.DO;
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
            return _employeeService.GetEmployees(new GetEmployeesRequest());
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
        public Guid? NewEmployee(string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            return _repository.NewEmployee(lastName, firstName, middleName, yearOfBirth, monthOfBirth, dayOfBirth);
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
        public bool UpdateEmployee(Guid id, string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            return _repository.UpdateEmployee(new DbEmployee(id, lastName, firstName, middleName, yearOfBirth, monthOfBirth, dayOfBirth));
        }
    }
}
