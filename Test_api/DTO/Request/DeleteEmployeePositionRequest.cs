using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for DeleteEmployeePosition
    /// </summary>
    public class DeleteEmployeePositionRequest
    {
        /// <summary>
        /// Employee id
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Position id
        /// </summary>
        public Guid PositionId { get; set; }
    }
}
