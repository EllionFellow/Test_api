﻿namespace Test_api.DTO.Request
{
    public class NewEmployeeRequest
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int YearOfBirth { get; set; }

        public int MonthOfBirth { get; set; }

        public int DayOfBirth { get; set; }
    }
}
