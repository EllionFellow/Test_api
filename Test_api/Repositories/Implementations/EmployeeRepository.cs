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
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                _connection.Open();
                var emp = new Employee();
                var dbEmployees = _connection.Query<DbEmployee>("SELECT \"id\", \"lastName\", \"firstName\", \"middleName\", \"birthDate\" FROM employee");
                List<Employee> employees = new List<Employee>();
                foreach (var item in dbEmployees)
                {
                    _mapper.Map(item, emp);
                    emp.Positions = _positionRepository.GetEmployeePositions(item.Id);
                    employees.Add(emp);
                    emp = new Employee();
                }
                return employees;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public Guid? NewEmployee(string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            var birthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            Guid id = Guid.NewGuid();
            DbEmployee emp = new DbEmployee(id, lastName, firstName, middleName, birthDate);
            try
            {
                _connection.Execute("INSERT INTO employee VALUES (@Id, @LastName, @FirstName, @MiddleName, @BirthDate)", emp);
                return id;
            }
            catch (Exception)
            {
                return null;
            }

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
            try
            {
                _connection.Execute("UPDATE employee SET " +
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

        ~EmployeeRepository()
        {
            _connection.Dispose();
        }
    }
}
