﻿using AutoMapper;
using System;
using Test_api.DO;
using Test_api.DTO.Request;
using Test_api.Repositories.Interfaces;
using Test_api.Services.Interfaces;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IEmployeePositionService
    /// <see cref="IEmployeePositionService"/>
    /// </summary>
    public class EmployeePositionService : IEmployeePositionService
    {
        #region DI

        private readonly IEmployeePositionRepository _employeePositionRepository;
        private readonly IMapper _mapper;

        public EmployeePositionService(IEmployeePositionRepository employeePositionRepository, IMapper mapper)
        {
            _employeePositionRepository = employeePositionRepository;
            _mapper = mapper;
        }

        #endregion

        /// <inheritdoc/>
        public void DeleteEmployeePosition(DeleteEmployeePositionRequest request)
        {
            _employeePositionRepository.DeleteEmployeePosition(_mapper.Map<DeleteEmployeePositionRequest, DbEmployeePosition>(request));
        }

        /// <inheritdoc/>
        public void NewEmployeePosition(NewEmployeePositionRequest request)
        {
            _employeePositionRepository.NewEmployeePosition(_mapper.Map<NewEmployeePositionRequest, DbEmployeePosition>(request));
        }

        /// <inheritdoc/>
        public void DeleteEmployee(Guid id)
        {
            _employeePositionRepository.DeleteEmployee(id);
        }

        /// <inheritdoc/>
        public bool IsPositionOccupied(Guid id)
        {
            return _employeePositionRepository.IsPositionOccupied(id);
        }
    }
}
