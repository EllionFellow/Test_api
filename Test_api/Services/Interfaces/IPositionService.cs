using System;
using System.Collections.Generic;
using Test_api.DTO;
using Test_api.DTO.Request;
using Test_api.DTO.Response;

namespace Test_api.Services.Interfaces
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
        /// <returns>All positions of employee <see cref="IEnumerable{T}"/><see cref="Position"/></returns>
        public IEnumerable<Position> GetPositions(Guid id);

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns><see cref="GetPositionResponse"/></returns>
        public GetPositionResponse GetPosition(Guid id);

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="Position"/><see cref="IEnumerable{T}"/></returns>
        public IEnumerable<Position> GetPositions();

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="request"><see cref="NewPositionRequest"/></param>
        public void NewPosition(NewPositionRequest request);

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="request"><see cref="DeletePositionRequest"/></param>
        public void DeletePosition(DeletePositionRequest request);

        /// <summary>
        /// Update existing position
        /// </summary>
        /// <param name="request"><see cref="UpdatePositionRequest"/></param>
        public void UpdatePosition(UpdatePositionRequest request);
    }
}
