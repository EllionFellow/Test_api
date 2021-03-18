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
        /// New employee year of birth
        /// </summary>
        public int YearOfBirth { get; set; }

        /// <summary>
        /// New employee month of birth
        /// </summary>
        public int MonthOfBirth { get; set; }

        /// <summary>
        /// New employee day of birth
        /// </summary>
        public int DayOfBirth { get; set; }
    }
}
