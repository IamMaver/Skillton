using Skillton.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Skillton.Core
{
    public class SkilltonContext : DbContext
    {
        public SkilltonContext(DbContextOptions<SkilltonContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=EmployeeDB;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<SkilltonContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new SkilltonContext(optionsBuilder.Options))
            {
                Console.WriteLine("Employee Management System");

                string choice = String.Empty;
                while (choice != "5")
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Add new employee");
                    Console.WriteLine("2. View all employees");
                    Console.WriteLine("3. Update employee information");
                    Console.WriteLine("4. Delete employee");
                    Console.WriteLine("5. Exit");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddEmployee(context);
                            break;
                        case "2":
                            ViewAllEmployees(context);
                            break;
                        case "3":
                            UpdateEmployee(context);
                            break;
                        case "4":
                            DeleteEmployee(context);
                            break;
                        case "5":
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

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

            context.Database.ExecuteSqlRaw("INSERT INTO Employees (FirstName, LastName, Email, DateOfBirth, Salary) VALUES ({0}, {1}, {2}, {3}, {4})",
                                            firstName, lastName, email, dateOfBirth, salary);

            Console.WriteLine("Employee added successfully.");
        }

        static void ViewAllEmployees(SkilltonContext context)
        {
            var employees = context.Employees;
            Console.WriteLine("All Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Email} {employee.DateOfBirth} {employee.Salary}");
            }
        }

        static void UpdateEmployee(SkilltonContext context)
        {
            Console.Write("Enter employee Id to update: ");
            var employeeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter updated employee details:");
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

            context.Database.ExecuteSqlRaw("UPDATE Employees SET FirstName = {0}, LastName = {1}, Email = {2}, DateOfBirth = {3}, Salary = {4} WHERE EmployeeID = {5}",
                                            firstName, lastName, email, dateOfBirth, salary, employeeId);

            Console.WriteLine("Employee information updated successfully.");
        }


        static void DeleteEmployee(SkilltonContext context)
        {
            Console.Write("Enter employee Id to delete: ");
            var employeeId = int.Parse(Console.ReadLine());

            context.Database.ExecuteSqlRaw("DELETE FROM Employees WHERE EmployeeID = {0}", employeeId);

            Console.WriteLine("Employee deleted successfully.");
        }
    }
}