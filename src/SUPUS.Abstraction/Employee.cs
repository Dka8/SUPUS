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

    public class ActionInfo
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool IsPresent { get; set; }
    }
}