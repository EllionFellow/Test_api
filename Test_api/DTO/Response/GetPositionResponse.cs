namespace Test_api.DTO.Response
{
    /// <summary>
    /// DTO for GetPositionResponse
    /// </summary>
    public class GetPositionResponse
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
