using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_api.Entity;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _repository;

        public PositionController(IPositionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>All positions <see cref="IEnumerable{T}"/></returns>
        [HttpGet]
        public IEnumerable<DbPosition> Get()
        {
            return _repository.GetPositions();
        }

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="name">Position name</param>
        /// <param name="grade">Position grade (1..15)</param>
        /// <returns>id if successful</returns>
        [HttpPut]
        public Guid? NewPosition(string name, int grade)
        {
            return _repository.NewPosition(name, grade);
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <returns>true if successful</returns>
        [HttpDelete]
        public bool DeletePosition(Guid id)
        {
            return _repository.DeletePosition(id);
        }

        /// <summary>
        /// Update position
        /// </summary>
        /// <param name="id">Position id</param>
        /// <param name="name">Position name</param>
        /// <param name="grade">Position grade</param>
        /// <returns>true if successful</returns>
        [HttpPost]
        public bool UpdatePosition(Guid id, string name, int grade)
        {
            return _repository.UpdatePosition(new DbPosition(id, name, grade));
        }
    }
}
