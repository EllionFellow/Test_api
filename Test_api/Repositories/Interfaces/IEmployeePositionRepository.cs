﻿using System;
using Test_api.DO;

namespace Test_api.Repositories.Interfaces
{
    /// <summary>
    /// Interface for connection employees to positions repository
    /// </summary>
    public interface IEmployeePositionRepository
    {
        /// <summary>
        /// Create employee to position connection
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <param name="positionId">Position id</param>
        public void NewEmployeePosition(DbEmployeePosition employeePosition);

        /// <summary>
        /// Delete employee to position connection
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <param name="positionId">Position id</param>
        public void DeleteEmployeePosition(DbEmployeePosition employeePosition);

        /// <summary>
        /// Is there an employee busy on concrete position
        /// </summary>
        /// <param name="positionId">Position id</param>
        /// <returns>True if position is occupied</returns>
        public bool IsPositionOccupied(Guid positionId);

        /// <summary>
        /// Delete all employee connections from EmployeePosition
        /// </summary>
        /// <param name="id">Employee id</param>
        public void DeleteEmployee(Guid id);
    }
}
