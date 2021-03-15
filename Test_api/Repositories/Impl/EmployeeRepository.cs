using Dapper;
using Npgsql;
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
        string dbConnection = "User ID = testapi; Password=testtest; Host=127.0.0.1; Port=5432; Database=Test_api_db;";

        /// <inheritdoc/>
        public IEnumerable<DBEmployee> GetEmployees()
        {

            using (IDbConnection db = new NpgsqlConnection(dbConnection))
            {
                try
                {
                    return db.Query<DBEmployee>("SELECT * FROM employee");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public Guid? NewEmployee(string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            var birthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            using (IDbConnection db = new NpgsqlConnection(dbConnection))
            {
                Guid id = Guid.NewGuid();
                DBEmployee emp = new DBEmployee(id, lastName, firstName, middleName, birthDate);
                try
                {
                    db.Execute("INSERT INTO employee VALUES (@Id, @LastName, @FirstName, @MiddleName, @BirthDate)", emp);
                    return id;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public bool DeleteEmployee(Guid id)
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnection))
            {
                try
                {
                    db.Execute("DELETE FROM employee WHERE \"id\" = @Id", new { id });
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <inheritdoc/>
        public bool UpdateEmployee(DBEmployee employee)
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnection))
            {
                try
                {
                    db.Execute("UPDATE employee SET " +
                        "\"lastName\" = @LastName, " +
                        "\"firstName\" = @FirstName, " +
                        "\"middleName\" = @MiddleName, " +
                        "\"birthDate\" = @BirthDate " +
                        "WHERE \"id\" = @Id", employee);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
