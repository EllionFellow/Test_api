using System;

namespace Test_api.DO
{
    /// <summary>
    /// Database employee - position connection class
    /// </summary>
    public class DbEmployeePosition
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
