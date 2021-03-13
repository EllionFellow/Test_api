using System;

namespace Test_api.DO
{
    /// <summary>
    /// Database employee class
    /// </summary>
    public class DBEmployee
    {
        /// <summary>
        /// Database employee id
        /// </summary>
        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
