using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.Entity;

namespace Test_api
{
    /// <summary>
    /// Interface for position service
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// Get all positions of concrete employee by "employee id"
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>All positions of employee <see cref="IEnumerable{T}"/><see cref="DbPosition"/></returns>
        public IEnumerable<DbPosition> GetPositions(Guid id);

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns><see cref="DbPosition"/></returns>
        public DbPosition GetPosition(Guid id);

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="DbPosition"/><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<DbPosition> GetPositions();

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="dbPosition"></param>
        public void NewPosition(NewPositionRequest request);

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id"></param>
        public void DeletePosition(DeletePositionRequest request);

        /// <summary>
        /// Update existing position
        /// </summary>
        /// <param name="dbPosition"></param>
        public void UpdatePosition(UpdatePositionRequest request);
    }
}
