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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IPositionService positionService)
        {
            _employeeRepository = employeeRepository;
            _positionService = positionService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public void DeleteEmployee(DeleteEmployeeRequest request)
        {
            try
            {
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

        /// <inheritdoc/>
        public void NewEmployee(NewEmployeeRequest request)
        {
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
