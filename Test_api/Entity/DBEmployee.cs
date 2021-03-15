using System;

namespace Test_api.DO
{
    /// <summary>
    /// Database employee class
    /// </summary>
    public class DBEmployee
    {
        /// <summary>
        /// Constructor for DBEmployee with int presentation of date
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="lastName">Employee last name</param>
        /// <param name="firstName">Employee first name</param>
        /// <param name="middleName">Employee middle name</param>
        /// <param name="yearOfBirth">Employee year of birth</param>
        /// <param name="monthOfBirth">Employee month of birth</param>
        /// <param name="dayOfBirth">Employee day of birth</param>
        public DBEmployee(Guid id, string lastName, string firstName, string middleName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
        }

        /// <summary>
        /// Constructor for DBEmployee with DateTime of date
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="lastName">Employee last name</param>
        /// <param name="firstName">Employee first name</param>
        /// <param name="middleName">Employee middle name</param>
        /// <param name="birthDate">Employee date of birth</param>
        public DBEmployee(Guid id, string lastName, string firstName, string middleName, DateTime birthDate)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
        }

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
