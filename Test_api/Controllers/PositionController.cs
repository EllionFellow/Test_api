using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using Test_api.DTO.Request;
using Test_api.DTO.Response;
using Test_api.Entity;
using Test_api.Services.Interfaces;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        #region DI

        private readonly IPositionService _positionService;
        private readonly ILogger _logger;

        public PositionController(IPositionService positionService, ILogger logger)
        {
            _positionService = positionService;
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="DbPosition"/><see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public ActionResult<IEnumerable<DbPosition>> GetPositions()
        {
            try
            {
                return Ok(_positionService.GetPositions());
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetPositions: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns><see cref="GetPositionResponse"/></returns>
        [HttpGet("{id:Guid}")]
        public ActionResult<GetPositionResponse> GetPosition(Guid id)
        {
            try
            {
                return Ok(_positionService.GetPosition(id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetPosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="request"><see cref="NewPositionRequest"/></param>
        [HttpPut]
        public ActionResult NewPosition(NewPositionRequest request)
        {
            try
            {
                _positionService.NewPosition(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Grade must be from 1 to 15, name can not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in NewPosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position id</param>
        [HttpDelete]
        public ActionResult DeletePosition(DeletePositionRequest request)
        {
            try
            {
                _positionService.DeletePosition(request);
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                return StatusCode((int)HttpStatusCode.MethodNotAllowed, $"Position with id {request.Id} is occupied");
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Id can not be empty");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in DeletePosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Update position
        /// </summary>
        /// <param name="request"><see cref="UpdatePositionRequest"/></param>
        [HttpPost]
        public ActionResult UpdatePosition(UpdatePositionRequest request)
        {
            try
            {
                _positionService.UpdatePosition(request);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, "Id and name can not be empty, grade must be from 1 to 15");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UpdatePosition: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
