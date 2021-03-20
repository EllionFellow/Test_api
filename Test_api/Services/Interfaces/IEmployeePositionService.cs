using System;
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

        /// <summary>
        /// Delete all positions of concrete employee
        /// </summary>
        /// <param name="id">Employee id</param>
        public void DeleteEmployee(Guid id);

        /// <summary>
        /// Check, if there is an employee, occupied on this position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>True if position is occupied</returns>
        public bool IsPositionOccupied(Guid id);
    }
}
