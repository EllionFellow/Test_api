﻿using Test_api.DTO.Request;
using Test_api.DTO.Response;

namespace Test_api.Services.Interfaces
{
    /// <summary>
    /// Interface for employee service
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="request"><see cref="GetEmployeesRequest"/></param>
        public GetEmployeesResponse GetEmployees();

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="request"><see cref="NewEmployeeRequest"/></param>
        public void NewEmployee(NewEmployeeRequest request);

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="request"><see cref="UpdateEmployeeRequest"/></param>
        public void UpdateEmployee(UpdateEmployeeRequest request);
    }
}
