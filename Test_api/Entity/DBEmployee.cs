using System;

namespace Test_api.DO
{
    /// <summary>
    /// Database employee class
    /// </summary>
    public class DbEmployee
    {
        /// <summary>
        /// Database employee id
        /// </summary>
        public Guid Id { get; set; }

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
        /// Date of birth NOT NULL
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
