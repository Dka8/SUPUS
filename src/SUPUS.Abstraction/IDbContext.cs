using System;
using System.Collections.Generic;

namespace SUPUS.Abstraction
{
    public interface IDbContext
    {
        IEnumerable<Employee> GetEmployees();
    }
}
