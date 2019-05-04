using System;
using System.Collections.Generic;

namespace SUPUS.Abstraction
{
    public interface IDbContext
    {
        IEnumerable<Employee> GetEmployees();
        void EmployeeAction(ActionInfo info);
        IEnumerable<TimeTable> GetTimeTable(int id);
    }
}
