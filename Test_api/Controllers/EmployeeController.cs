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
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DBEmployee> Get()
        {
            return _repository.GetEmployees();
        }

        /// <summary>
        /// Create new employee
        /// </summary>
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
        /// <returns></returns>
        [HttpDelete]
        public bool DeleteEmployee(Guid id)
        {
            return _repository.DeleteEmployee(id);
        }

        [HttpPost]
        public bool UpdateEmployee(Guid id, string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            return _repository.UpdateEmployee(new DBEmployee(id, lastName, firstName, middleName, yearOfBirth, monthOfBirth, dayOfBirth));
        }
    }
}
