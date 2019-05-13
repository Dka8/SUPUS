using SUPUS.Abstraction;
using System;
using System.Collections.Generic;

namespace SUPUS.FakeDatabase
{
    public class FakeDbContext : IDbContext
    {
        public void EmployeeAction(ActionInfo info)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            yield return new Employee { Id =1, Email = "email@mail.ru", FirstName = "Igor", LastName = "Ivanov", MiddleName = "Ivanovich", Shift = new ShiftType { Begin = "4", End = "4444" } };
            yield return new Employee { Id = 2, Email = "noemail@mail.ru", FirstName = "Dima", LastName = "Martunov", Shift = new ShiftType { Begin = "444", End = "444" } };
        }

        public IEnumerable<ShiftType> GetShiftTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeTable> GetTimeTable(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
