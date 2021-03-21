using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<DbPosition>> GetPositions()
        {
            try
            {
                return Ok(_positionService.GetPositions());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        public ActionResult<GetPositionResponse> GetPosition(Guid id)
        {
            try
            {
                return Ok(_positionService.GetPosition(id));
            }
            catch (Exception e)
            {
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
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>true if successful</returns>
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
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
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
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
