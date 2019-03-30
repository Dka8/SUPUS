using SUPUS.Abstraction;
using System;
using System.Collections.Generic;

namespace SUPUS.FakeDatabase
{
    public class FakeDbContext : IDbContext
    {
        public IEnumerable<Employee> GetEmployees()
        {
            yield return new Employee { Id =1, Email = "email@mail.ru", FirstName = "Igor", LastName = "Ivanov", MiddleName = "Ivanovich", Shift = new ShiftType { Number = 2, Begin = TimeSpan.MinValue, End = TimeSpan.MinValue } };
            yield return new Employee { Id = 2, Email = "noemail@mail.ru", FirstName = "Dima", LastName = "Martunov", Shift = new ShiftType {Number = 1, Begin = TimeSpan.MinValue, End = TimeSpan.MinValue } };
        }
    }
}
