using Microsoft.Data.Sqlite;
using SUPUS.Abstraction;
using System;
using System.Collections.Generic;

namespace SUPUS.SqliteDatabase
{
    public class SqliteDbContext : IDbContext
    {
        private const string EmployeeTable =
            @"CREATE TABLE Employee(
                Id INTEGER PRIMARY KEY,
                Email VARCHAR(50) NOT NULL UNIQUE,
                FirstName VARCHAR(50) NOT NULL,
                LastName VARCHAR(50) NOT NULL,
                MiddleName VARCHAR(50)                
            );";

        private const string PopulateEmployee =
            @"INSERT INTO Employee 
                (Email, FirstName, LastName, MiddleName)
                VALUES 
                ('gg1@mail.ru','Snya','Petrov',''),
                ('gg2@mail.ru','Snya','Petrov',''),
                ('gg3@mail.ru','Snya','Petrov',''),
                ('gg4@mail.ru','Snya','Petrov',NULL)
            ;";

        private SqliteConnection _connection;

        public SqliteDbContext()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            ExecuteNonQuery(EmployeeTable);
            ExecuteNonQuery(PopulateEmployee);
        }

        private void ExecuteNonQuery(string command)
        {
            (new SqliteCommand(command, _connection)).ExecuteNonQuery();
        }


        public IEnumerable<Employee> GetEmployees()
        {
            var command = _connection.CreateCommand();
            command.CommandText =
                @"SELECT Id, Email, FirstName, LastName, MiddleName
                FROM Employee
                ORDER BY Id";

            var reader = command.ExecuteReader();

            var employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    MiddleName = reader.IsDBNull(4) ? String.Empty : reader.GetString(4)
                };
                employees.Add(employee);
            }

            return employees;
        }
    }
}
