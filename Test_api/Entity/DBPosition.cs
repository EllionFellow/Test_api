using System;

namespace Test_api.Entity
{
    /// <summary>
    /// Database presentation of position
    /// </summary>
    public class DbPosition
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
