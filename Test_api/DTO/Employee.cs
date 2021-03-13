using System;

namespace Test_api
{
    /// <summary>
    /// DO for Employee
    /// </summary>
    public class Employee
    {
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
    }
}
