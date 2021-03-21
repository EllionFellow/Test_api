using AutoMapper;
using System;
using System.Collections.Generic;
using Test_api.DO;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Services.Interfaces;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IEmployeeService
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        #region DI

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;
        private readonly IEmployeePositionService _employeePositionService;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IPositionService positionService, IEmployeePositionService employeePositionService)
        {
            _employeeRepository = employeeRepository;
            _positionService = positionService;
            _employeePositionService = employeePositionService;
            _mapper = mapper;
        }

        #endregion

        /// <inheritdoc/>
        public void DeleteEmployee(DeleteEmployeeRequest request)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            try
            {
                _employeePositionService.DeleteEmployee(request.Id);
                _employeeRepository.DeleteEmployee(request.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public GetEmployeesResponse GetEmployees()
        {
            var response = _employeeRepository.GetEmployees();
            var employees = new List<Employee>();
            foreach (var item in response)
            {
                var employee = _mapper.Map<DbEmployee, Employee>(item);
                employee.Positions = _positionService.GetPositions(employee.Id);
                employees.Add(employee);
            }
            IEnumerable<Employee> result = employees;
            return new GetEmployeesResponse(result);
        }

        ///<inheritdoc/>
        public GetEmployeeResponse GetEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            var emp = _mapper.Map<DbEmployee, Employee>(_employeeRepository.GetEmployee(id));
            emp.Positions = _positionService.GetPositions(emp.Id);
            return _mapper.Map<Employee, GetEmployeeResponse>(emp);
        }

        /// <inheritdoc/>
        public void NewEmployee(NewEmployeeRequest request)
        {
            if (request.FirstName==string.Empty || request.LastName == string.Empty || request.MonthOfBirth>12 || request.YearOfBirth<1800 || request.YearOfBirth>(DateTime.Now.Year-16))
            {
                throw new ArgumentException();
            }
            try
            {
                var dbEmp = _mapper.Map<NewEmployeeRequest, DbEmployee>(request);
                dbEmp.Id = Guid.NewGuid();
                _employeeRepository.NewEmployee(dbEmp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void UpdateEmployee(UpdateEmployeeRequest request)
        {
            if (request.Id == Guid.Empty || request.FirstName == string.Empty || request.LastName == string.Empty || request.MonthOfBirth > 12 || request.YearOfBirth < 1800 || request.YearOfBirth > (DateTime.Now.Year - 16))
            {
                throw new ArgumentException();
            }
            try
            {
                _employeeRepository.UpdateEmployee(_mapper.Map<UpdateEmployeeRequest, DbEmployee>(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
