using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return new List<Employee> {
                new Employee {
                    BirthDate = new DateTime (1992,10,15),
                    FirstName = "Alexei",
                    LastName = "Sorotsky",
                    MiddleName = "Anatolievich",
                },
                new Employee {
                    BirthDate = new DateTime (2000,8,22),
                    FirstName = "Ivan",
                    LastName = "Petrov",
                }
            };
        }
    }
}
