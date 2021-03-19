using System;

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
