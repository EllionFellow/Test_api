using System;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for UpdateEmployeeRequest
    /// </summary>
    public class UpdateEmployeeRequest
    {
        /// <summary>
        /// Employee id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Employee last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Employee first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Employee middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Employee date of birth
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
