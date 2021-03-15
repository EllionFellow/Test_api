using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
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
        public IConfiguration Configuration { get; }
        private readonly string _dbConnect;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;

        public EmployeeRepository(IConfiguration configuration, IPositionRepository positionRepository, IMapper mapper)
        {
            Configuration = configuration;
            _dbConnect = Configuration.GetConnectionString("dbConnection");
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        

        /// <inheritdoc/>
        public IEnumerable<Employee> GetEmployees()
        {
            using (IDbConnection db = new NpgsqlConnection(_dbConnect))
            {
                try
                {
                    var emp = new Employee();
                    var dbEmployees = db.Query<DBEmployee>("SELECT * FROM employee");
                    List<Employee> employees = new List<Employee>();
                    foreach (var item in dbEmployees)
                    {
                        _mapper.Map(item, emp);
                        emp.Positions = _positionRepository.GetEmployeePositions(item);
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
        }

        /// <inheritdoc/>
        public Guid? NewEmployee(string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            var birthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            using (IDbConnection db = new NpgsqlConnection(_dbConnect))
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
            using (IDbConnection db = new NpgsqlConnection(_dbConnect))
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
            using (IDbConnection db = new NpgsqlConnection(_dbConnect))
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
