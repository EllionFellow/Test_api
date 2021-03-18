using System;
using System.Collections.Generic;
using Test_api.Entity;

namespace Test_api.Services.Implementations
{
    /// <summary>
    /// Implementation of IPositionService
    /// </summary>
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public IEnumerable<DbPosition> GetPositions(Guid id)
        {
            return _positionRepository.GetEmployeePositions(id);
        }
    }
}
