using System.Collections.Generic;

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
