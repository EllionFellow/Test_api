using System;

namespace Test_api.DTO.Request
{
    /// <summary>
    /// DTO for NewEmployeeRequest
    /// </summary>
    public class NewEmployeeRequest
    {
        /// <summary>
        /// New employee last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// New employee first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// New employee middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
