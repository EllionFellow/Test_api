using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using Test_api.DTO.Request;
using Test_api.Services.Interfaces;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeePositionController : ControllerBase
    {
        #region DI

        private readonly IEmployeePositionService _employeePositionService;
        private readonly ILogger _logger;

        public EmployeePositionController(IEmployeePositionService employeePositionService, ILogger logger)
        {
            _employeePositionService = employeePositionService;
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// Create new employee - position connection
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public ActionResult NewEmployeePosition(NewEmployeePositionRequest request)
        {
            try
            {
                _employeePositionService.NewEmployeePosition(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Employee id and position can not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in NewEmployeePosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Delete employee - position connection
        /// </summary>
        /// <param name="request"></param>
        [HttpDelete]
        public ActionResult DeleteEmployeePosition(DeleteEmployeePositionRequest request)
        {
            try
            {
                _employeePositionService.DeleteEmployeePosition(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Employee id and position can not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in DeleteEmployeePosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
