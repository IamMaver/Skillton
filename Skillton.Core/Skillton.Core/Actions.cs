/*using Microsoft.EntityFrameworkCore;
using Skillton.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillton.Core
{
    static void AddEmployee(SkilltonContext context)
    {
        Console.WriteLine("Enter employee details:");
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Date of Birth (YYYY-MM-DD): ");
        var dateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Salary: ");
        var salary = decimal.Parse(Console.ReadLine());

        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            DateOfBirth = dateOfBirth,
            Salary = salary
        };

        // Используем параметры запроса для передачи значений в SQL-запрос
        context.Database.ExecuteSqlRaw("INSERT INTO Employees (FirstName, LastName, Email, DateOfBirth, Salary) VALUES ({0}, {1}, {2}, {3}, {4})",
                                        firstName, lastName, email, dateOfBirth, salary);

        Console.WriteLine("Employee added successfully.");
    }

}
*/