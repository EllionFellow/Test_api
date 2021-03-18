using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_api.DTO.Response
{
    /// <summary>
    /// DTO for GetEmployeesResponse
    /// </summary>
    public class GetEmployeesResponse
    {
        public IEnumerable<Employee> Employees { get; set; }

        public GetEmployeesResponse(IEnumerable<Employee> val)
        {
            Employees = val;
        }
    }
}
