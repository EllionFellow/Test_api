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
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;

        public EmployeeRepository(IDbConnection connection, IPositionRepository positionRepository, IMapper mapper)
        {
            _connection = connection;
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

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

        /// <inheritdoc/>
        public void NewEmployee(DbEmployee employee)
        {
            _connection.Execute("INSERT INTO employee VALUES (@Id, @LastName, @FirstName, @MiddleName, @BirthDate)", employee);
        }

        /// <inheritdoc/>
        public bool DeleteEmployee(Guid id)
        {
            try
            {
                _connection.Execute("DELETE FROM employee WHERE \"id\" = @Id", new { id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <inheritdoc/>
        public bool UpdateEmployee(DbEmployee employee)
        {
            _connection.Execute("UPDATE employee SET " +
                "\"lastName\" = @LastName, " +
                "\"firstName\" = @FirstName, " +
                "\"middleName\" = @MiddleName, " +
                "\"birthDate\" = @BirthDate " +
                "WHERE \"id\" = @Id", employee);
            return true;
        }

        ~EmployeeRepository()
        {
            _connection.Dispose();
        }
    }
}
