using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Services.Interfaces;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region DI

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees <see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public GetEmployeesResponse GetEmployees()
        {
            try
            {
                return _employeeService.GetEmployees();
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        /// <summary>
        /// Get employee
        /// </summary>
        /// <returns>Employee<see cref="Employee"/></returns>
        [HttpGet("{id:Guid}")]
        public GetEmployeeResponse GetEmployee(Guid id)
        {
            try
            {
                return _employeeService.GetEmployee(id);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
                return null;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }
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
            try
            {
                _employeeService.NewEmployee(request);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="request"><see cref="DeleteEmployeeRequest"/></param>
        [HttpDelete]
        public void DeleteEmployee(DeleteEmployeeRequest request)
        {
            try
            {
                _employeeService.DeleteEmployee(request);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
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
        [HttpPost]
        public void UpdateEmployee(UpdateEmployeeRequest request)
        {
            try
            {
                _employeeService.UpdateEmployee(request);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
        }
    }
}
