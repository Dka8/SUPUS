using System;
using System.Collections.Generic;
using SUPUS.Abstraction;

namespace SUPUS.Database
{
    public class DbContext : IDbContext
    {
        public void EmployeeAction(ActionInfo info)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
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
