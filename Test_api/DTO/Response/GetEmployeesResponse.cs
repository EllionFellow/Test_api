using System.Collections.Generic;

namespace Test_api.DTO.Response
{
    /// <summary>
    /// DTO for GetEmployeesResponse
    /// </summary>
    public class GetEmployeesResponse
    {
        /// <summary>
        /// <see cref="Employee"/>
        /// <see cref="IEnumerable"/>
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val"></param>
        public GetEmployeesResponse(IEnumerable<Employee> val)
        {
            Employees = val;
        }
    }
}
