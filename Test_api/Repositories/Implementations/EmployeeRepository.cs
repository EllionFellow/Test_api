using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Test_api.DO;

namespace Test_api
{
    /// <summary>
    /// Implementation of IEmployeeRepository
    /// <see cref="IEmployeeRepository"/>
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region DI

        private readonly IDbConnection _connection;

        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #endregion

        /// <inheritdoc/>
        public IEnumerable<DbEmployee> GetEmployees()
        {
            try
            {
                _connection.Open();
                var dbEmployees = _connection.Query<DbEmployee>("SELECT \"id\", \"lastName\", \"firstName\", \"middleName\", \"birthDate\" FROM employee");
                return dbEmployees;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbEmployee GetEmployee(Guid id)
        {
            return _connection.QuerySingle<DbEmployee>("SELECT \"id\", \"lastName\", \"firstName\", \"middleName\", \"birthDate\" FROM employee WHERE id = @id", new { id });
        }

        /// <inheritdoc/>
        public void NewEmployee(DbEmployee employee)
        {
            _connection.Execute("INSERT INTO employee VALUES (@Id, @LastName, @FirstName, @MiddleName, @BirthDate)", employee);
        }

        /// <inheritdoc/>
        public void DeleteEmployee(Guid id)
        {
            _connection.Execute("DELETE FROM employee WHERE \"id\" = @Id", new { id });
        }

        /// <inheritdoc/>
        public void UpdateEmployee(DbEmployee employee)
        {
            _connection.Execute("UPDATE employee SET " +
                "\"lastName\" = @LastName, " +
                "\"firstName\" = @FirstName, " +
                "\"middleName\" = @MiddleName, " +
                "\"birthDate\" = @BirthDate " +
                "WHERE \"id\" = @Id", employee);
        }

        ~EmployeeRepository()
        {
            _connection.Dispose();
        }
    }
}
