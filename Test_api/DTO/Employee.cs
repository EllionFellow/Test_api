using System;
using System.Collections.Generic;
using Test_api.Entity;

namespace Test_api
{
    /// <summary>
    /// DTO for Employee
    /// </summary>
    public class Employee
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
        /// Last name field(�������) NOT NULL
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First name field(���) NOT NULL
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name field(��������) 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Positions of employee
        /// </summary>
        public IEnumerable<DbPosition> Positions { get; set; }
    }
}
