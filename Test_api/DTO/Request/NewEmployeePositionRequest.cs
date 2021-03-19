using System;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for NewEmployeePosition
    /// </summary>
    public class NewEmployeePositionRequest
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
