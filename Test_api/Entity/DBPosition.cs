using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_api.Entity
{
    /// <summary>
    /// Database presentation of position
    /// </summary>
    public class DBPosition
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
