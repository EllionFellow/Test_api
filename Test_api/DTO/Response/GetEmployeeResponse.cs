using System;
using System.Collections.Generic;

namespace Test_api.DTO.Response
{
    /// <summary>
    /// DTO for GetEmployeeResponse
    /// </summary>
    public class GetEmployeeResponse
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of birth NOT NULL
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Last name field(фамилия) NOT NULL
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First name field(имя) NOT NULL
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name field(отчество) 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Positions of employee
        /// </summary>
        public IEnumerable<Position> Positions { get; set; }
    }
}
