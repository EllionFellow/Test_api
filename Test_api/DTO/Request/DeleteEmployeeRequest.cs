using System;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for DeleteEmployeeRequest
    /// </summary>
    public class DeleteEmployeeRequest
    {
        /// <summary>
        /// Employee id
        /// </summary>
        public Guid Id { get; set; }
    }
}
