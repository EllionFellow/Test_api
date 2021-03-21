using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Entity;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        #region DI

        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        #endregion

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="DbPosition"/><see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public IEnumerable<DbPosition> GetPositions()
        {
            try
            {
                return _positionService.GetPositions();
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        public GetPositionResponse GetPosition(Guid id)
        {
            try
            {
                return _positionService.GetPosition(id);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="request"><see cref="NewPositionRequest"/></param>
        [HttpPut]
        public void NewPosition(NewPositionRequest request)
        {
            try
            {
                _positionService.NewPosition(request);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>true if successful</returns>
        [HttpDelete]
        public void DeletePosition(DeletePositionRequest request)
        {
            try
            {
                _positionService.DeletePosition(request);
            }
            catch (ArgumentOutOfRangeException)
            {
                HttpContext.Response.StatusCode = 404;
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
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
            try
            {
                _positionService.UpdatePosition(request);
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 406;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
            }
        }
    }
}
