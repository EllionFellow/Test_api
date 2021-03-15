using System;
using System.Collections.Generic;
using Test_api.DO;
using Test_api.Entity;

namespace Test_api
{
    /// <summary>
    /// Interface for position repository
    /// </summary>
    public interface IPositionRepository
    {
        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<DBPosition> GetPositions();

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="name">Name of new position</param>
        /// <param name="grade">Grade of new position</param>
        /// <returns>Id if successful, else null</returns>
        public Guid? NewPosition(string name, int grade);

        /// <summary>
        /// Delete position by ID
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>true, if successful</returns>
        public bool DeletePosition(Guid id);

        /// <summary>
        /// Change position
        /// </summary>
        /// <param name="employee">New position data (id cannot be changed)</param>
        /// <returns>true, if successful</returns>
        public bool UpdatePosition(DBPosition position);

        /// <summary>
        /// Get all positions of an employee
        /// </summary>
        /// <param name="employee"><see cref="DBEmployee"/></param>
        /// <returns>All positions of employee <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<DBPosition> GetEmployeePositions(DBEmployee employee);
    }
}
