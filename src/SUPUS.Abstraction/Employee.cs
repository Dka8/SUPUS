using System;

namespace SUPUS.Abstraction
{
    public class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ShiftType Shift { get; set; }
    }

    public class ShiftType
    {
        public int Number { get; set; }
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }
    }
}