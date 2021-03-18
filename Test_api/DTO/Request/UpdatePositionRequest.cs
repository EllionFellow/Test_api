using System;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for UpdatePositionRequest
    /// </summary>
    public class UpdatePositionRequest
    {
        /// <summary>
        /// Position id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Position name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Position grade 1..15
        /// </summary>
        public int Grade { get; set; }
    }
}
