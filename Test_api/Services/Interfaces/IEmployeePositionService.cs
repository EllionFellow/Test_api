using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_api.DTO.Request;

namespace Test_api.Services.Interfaces
{
    /// <summary>
    /// Interface for EmployeePositionService
    /// </summary>
    public interface IEmployeePositionService
    {
        /// <summary>
        /// Create employee - position connection
        /// </summary>
        /// <param name="request"><see cref="NewEmployeePositionRequest"/></param>
        public void NewEmployeePosition(NewEmployeePositionRequest request);

        /// <summary>
        /// Delete employee - position connection
        /// </summary>
        /// <param name="request"><see cref="DeleteEmployeePositionRequest"/></param>
        public void DeleteEmployeePosition(DeleteEmployeePositionRequest request);
    }
}
