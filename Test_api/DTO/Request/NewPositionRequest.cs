namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for NewPositionRequest
    /// </summary>
    public class NewPositionRequest
    {
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
