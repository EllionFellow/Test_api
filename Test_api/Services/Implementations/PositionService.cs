using AutoMapper;
using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.Entity;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IPositionService
    /// </summary>
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public void NewPosition(NewPositionRequest request)
        {
            DbPosition dbPosition = _mapper.Map<NewPositionRequest, DbPosition>(request);
            dbPosition.Id = Guid.NewGuid();
            _positionRepository.NewPosition(dbPosition);
        }

        /// <inheritdoc/>
        public void DeletePosition(DeletePositionRequest request)
        {
            _positionRepository.DeletePosition(request.Id);
        }

        /// <inheritdoc/>
        public DbPosition GetPosition(Guid id)
        {
            return _positionRepository.GetPosition(id);
        }

        /// <inheritdoc/>
        public IEnumerable<DbPosition> GetPositions(Guid id)
        {
            return _positionRepository.GetEmployeePositions(id);
        }

        /// <inheritdoc/>
        public void UpdatePosition(UpdatePositionRequest request)
        {
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
