using System;
using System.Collections.Generic;
using Test_api.DO;

namespace Test_api
{
    /// <summary>
    /// Interface for employee repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<DbEmployee> GetEmployees();

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns></returns>
        public DbEmployee GetEmployee(Guid id);

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="employee"><see cref="DbEmployee"/></param>
        public void NewEmployee(DbEmployee employee);

        /// <summary>
        /// Delete emloyee by ID
        /// </summary>
        /// <param name="id">Employee id</param>
        public void DeleteEmployee(Guid id);

        /// <summary>
        /// Change employee
        /// </summary>
        /// <param name="employee"><see cref="DbEmployee"/></param>
        public void UpdateEmployee(DbEmployee employee);
    }
}
