using System;
using System.Collections.Generic;
using Test_api.Entity;

namespace Test_api
{
    /// <summary>
    /// Interface for position repository
    /// </summary>
    public interface IPositionRepository
    {
        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="dbPosition"><see cref="DbPosition"/></param>
        public void NewPosition(DbPosition dbPosition);

        /// <summary>
        /// Delete position by ID
        /// </summary>
        /// <param name="id">Position id</param>
        public void DeletePosition(Guid id);

        /// <summary>
        /// Change position
        /// </summary>
        /// <param name="employee"><see cref="DbPosition"/></param>
        public void UpdatePosition(DbPosition position);

        /// <summary>
        /// Get all positions of an employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>All positions of employee <see cref="IEnumerable{T}"/><see cref="DbPosition"/></returns>
        public IEnumerable<DbPosition> GetEmployeePositions(Guid id);

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions of employee <see cref="IEnumerable{T}"/><see cref="DbPosition"/></returns>
        public IEnumerable<DbPosition> GetPositions();

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns><see cref="DbPosition"/></returns>
        public DbPosition GetPosition(Guid id);
    }
}
