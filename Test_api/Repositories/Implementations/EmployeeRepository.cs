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

        private readonly IDbConnection _db;

        public EmployeeRepository(IDbConnection connection)
        {
            _db = connection;
        }

        #endregion

        /// <inheritdoc/>
        public IEnumerable<DbEmployee> GetEmployees()
        {
            try
            {
                var dbEmployees = _db.Query<DbEmployee>("SELECT \"id\", \"lastName\", \"firstName\", \"middleName\", \"birthDate\" FROM employee");
                return dbEmployees;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbEmployee GetEmployee(Guid id)
        {
            return _db.QuerySingle<DbEmployee>("SELECT \"id\", \"lastName\", \"firstName\", \"middleName\", \"birthDate\" FROM employee WHERE id = @id", new { id });
        }

        /// <inheritdoc/>
        public void NewEmployee(DbEmployee employee)
        {
            _db.Execute("INSERT INTO employee VALUES (@Id, @LastName, @FirstName, @MiddleName, @BirthDate)", employee);
        }

        /// <inheritdoc/>
        public void DeleteEmployee(Guid id)
        {
            _db.Execute("DELETE FROM employee WHERE \"id\" = @Id", new { id });
        }

        /// <inheritdoc/>
        public void UpdateEmployee(DbEmployee employee)
        {
            _db.Execute("UPDATE employee SET " +
                "\"lastName\" = @LastName, " +
                "\"firstName\" = @FirstName, " +
                "\"middleName\" = @MiddleName, " +
                "\"birthDate\" = @BirthDate " +
                "WHERE \"id\" = @Id", employee);
        }

        ~EmployeeRepository()
        {
            _db.Dispose();
        }
    }
}
