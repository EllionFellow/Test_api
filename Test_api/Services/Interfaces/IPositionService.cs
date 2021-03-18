using System;
using System.Collections.Generic;
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
    }
}
