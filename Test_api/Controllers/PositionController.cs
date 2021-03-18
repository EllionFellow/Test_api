using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.Entity;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="DbPosition"/><see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public IEnumerable<DbPosition> Get()
        {
            return _positionService.GetPositions();
        }

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="request"><see cref="NewPositionRequest"/></param>
        [HttpPut]
        public void NewPosition(NewPositionRequest request)
        {
            _positionService.NewPosition(request);
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>true if successful</returns>
        [HttpDelete]
        public void DeletePosition(DeletePositionRequest request)
        {
            _positionService.DeletePosition(request);
        }

        /// <summary>
        /// Update position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <param name="name">Position name</param>
        /// <param name="grade">Position grade</param>
        /// <returns>true if successful</returns>
        [HttpPost]
        public void UpdatePosition(UpdatePositionRequest request)
        {
            _positionService.UpdatePosition(request);
        }
    }
}
