using Microsoft.AspNetCore.Mvc;
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

        public EmployeePositionController(IEmployeePositionService employeePositionService)
        {
            _employeePositionService = employeePositionService;
        }

        #endregion

        /// <summary>
        /// Create new employee - position connection
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("NewEmployeePosition")]
        public void NewEmployeePosition(NewEmployeePositionRequest request)
        {
            try
            {
                _employeePositionService.NewEmployeePosition(request);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
            
        }

        /// <summary>
        /// Delete employee - position connection
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("DeleteEmployeePosition")]
        public void DeleteEmployeePosition(DeleteEmployeePositionRequest request)
        {
            try
            {
                _employeePositionService.DeleteEmployeePosition(request);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
        }
    }
}
