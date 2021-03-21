using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees <see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public ActionResult<GetEmployeesResponse> GetEmployees()
        {
            try
            {
                return Ok(_employeeService.GetEmployees());
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetEmployees: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get employee
        /// </summary>
        /// <returns>Employee<see cref="Employee"/></returns>
        [HttpGet("{id:Guid}")]
        public ActionResult<GetEmployeeResponse> GetEmployee(Guid id)
        {
            try
            {
                return Ok(_employeeService.GetEmployee(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"User with id {id} not found");
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "id can not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetEmployee: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
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
        public ActionResult NewEmployee(NewEmployeeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            try
            {
                _employeeService.NewEmployee(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, @"Last name and first name could not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in NewEmployee: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="request"><see cref="DeleteEmployeeRequest"/></param>
        [HttpDelete]
        public ActionResult DeleteEmployee(DeleteEmployeeRequest request)
        {
            try
            {
                _employeeService.DeleteEmployee(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Id can not be null");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in DeleteEmployee: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
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
        public ActionResult UpdateEmployee(UpdateEmployeeRequest request)
        {
            try
            {
                _employeeService.UpdateEmployee(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Id can not be null, last name and first name could not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UpdateEmployee: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
