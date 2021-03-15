using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.DO;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees <see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _repository.GetEmployees();
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
            return _repository.UpdateEmployee(new DBEmployee(id, lastName, firstName, middleName, yearOfBirth, monthOfBirth, dayOfBirth));
        }
    }
}
