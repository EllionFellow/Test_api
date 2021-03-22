using System;

namespace Test_api.DTO
{
    /// <summary>
    /// Model for employee - position connection
    /// </summary>
    public class EmployeePosition
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
