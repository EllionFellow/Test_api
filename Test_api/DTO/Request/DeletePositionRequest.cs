using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for DeletePositionRequest
    /// </summary>
    public class DeletePositionRequest
    {
        /// <summary>
        /// Position id
        /// </summary>
        public Guid Id { get; set; }
    }
}
