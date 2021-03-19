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
        /// <param name="id"><see cref="DbEmployee"/></param>
        /// <returns></returns>
        public DbEmployee GetEmployee(Guid id);

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="lastName">Last name (фамилия)</param>
        /// <param name="firstName">First name (имя)</param>
        /// <param name="middleName">Middle name (отчество) - nullable(не обязательно)</param>
        /// <param name="birthDate">Date of birth (дата рождения)</param>
        /// <returns>id if successful, else null</returns>
        public void NewEmployee(DbEmployee employee);

        /// <summary>
        /// Delete emloyee by ID
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>true, if successful</returns>
        public void DeleteEmployee(Guid id);

        /// <summary>
        /// Change employee
        /// </summary>
        /// <param name="employee">New employee data (id cannot be changed)</param>
        /// <returns>true, if successful</returns>
        public void UpdateEmployee(DbEmployee employee);
    }
}
