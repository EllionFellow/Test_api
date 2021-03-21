using AutoMapper;
using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Entity;
using Test_api.Services.Interfaces;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IPositionService
    /// </summary>
    public class PositionService : IPositionService
    {
        #region DI

        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeePositionService _employeePositionService;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IEmployeePositionService employeePositionService, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _employeePositionService = employeePositionService;
            _mapper = mapper;
        }

        #endregion

        /// <inheritdoc/>
        public void NewPosition(NewPositionRequest request)
        {
            if (request.Grade < 0 || request.Grade > 15 || request.Name==string.Empty) throw new ArgumentException();
            DbPosition dbPosition = _mapper.Map<NewPositionRequest, DbPosition>(request);
            dbPosition.Id = Guid.NewGuid();
            _positionRepository.NewPosition(dbPosition);
        }

        /// <inheritdoc/>
        public void DeletePosition(DeletePositionRequest request)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            if (!_employeePositionService.IsPositionOccupied(request.Id))
            {
                _positionRepository.DeletePosition(request.Id);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <inheritdoc/>
        public GetPositionResponse GetPosition(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            return _mapper.Map<DbPosition, GetPositionResponse>(_positionRepository.GetPosition(id));
        }

        /// <inheritdoc/>
        public IEnumerable<DbPosition> GetPositions(Guid id)
        {
            return _positionRepository.GetEmployeePositions(id);
        }

        /// <inheritdoc/>
        public void UpdatePosition(UpdatePositionRequest request)
        {
            if (request.Grade < 0 || request.Grade > 15 || request.Name == string.Empty || request.Id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            var dbPosition = _mapper.Map<UpdatePositionRequest, DbPosition>(request);
            _positionRepository.UpdatePosition(dbPosition);
        }

        /// <inheritdoc/>
        public IEnumerable<DbPosition> GetPositions()
        {
            return _positionRepository.GetPositions();
        }
    }
}
