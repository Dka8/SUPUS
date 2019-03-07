using System;
using System.Collections.Generic;
using SUPUS.Abstraction;

namespace SUPUS.Database
{
    public class DbContext : IDbContext
    {
        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
