using Microsoft.Data.Sqlite;
using SUPUS.Abstraction;
using System;
using System.Collections.Generic;

namespace SUPUS.SqliteDatabase
{
    public class SqliteDbContext : IDbContext
    {
        private const string EmployeeTable =
            @"CREATE TABLE EMPLOYEE(
                EMPLOYEE_ID INTEGER PRIMARY KEY,
                EMAIL VARCHAR(50) NOT NULL UNIQUE,
                FIRST_NAME VARCHAR(50) NOT NULL,
                LAST_NAME VARCHAR(50) NOT NULL,
                MIDDLE_NAME VARCHAR(50),
                SHIFT_NUMBER INTEGER
            );";

        private const string PopulateEmployee =
            @"INSERT INTO EMPLOYEE
                (EMAIL, FIRST_NAME, LAST_NAME, MIDDLE_NAME, SHIFT_NUMBER)
                VALUES 
                ('gg1@mail.ru','Snya','Petrov','',1),
                ('gg2@mail.ru','Snya','Petrov','',2),
                ('gg3@mail.ru','Snya','Petrov','',1),
                ('gg4@mail.ru','Snya','Petrov',NULL,1)
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
                @"SELECT EMPLOYEE_ID, EMAIL, FIRST_NAME, LAST_NAME, MIDDLE_NAME, SHIFT_NUMBER
                FROM EMPLOYEE
                ORDER BY EMPLOYEE_ID";

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
                    MiddleName = reader.IsDBNull(4) ? String.Empty : reader.GetString(4),
                    ShiftNumber = reader.GetInt32(5)
                };
                employees.Add(employee);
            }

            return employees;
        }
    }
}
