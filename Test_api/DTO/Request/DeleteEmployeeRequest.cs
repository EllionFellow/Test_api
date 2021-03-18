using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
