using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompanyProject
{
    class Program
    {
        static List<string> employees = new List<string>();
        void addEmployee()
        {
            try {

                Console.WriteLine("Enter employee name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter employee ID:");
                int id = int.Parse(Console.ReadLine());
                if (employees.Exists(e => e.Contains($"ID: {id}")))
                {
                    Console.WriteLine("Employee with this ID already exists. Please enter a unique ID.");
                    return;
                }

                Console.WriteLine("Enter employee department:");
                string department = Console.ReadLine();

                Console.WriteLine("Enter employee Grade:");
                char grade = char.Parse(Console.ReadLine());
                grade = char.ToUpper(grade);

                if (grade < 'A' || grade > 'F')
                {
                    Console.WriteLine("Invalid grade. Please enter a grade between A and F.");
                    return;
                }
                decimal salary;
                switch (grade)
                {
                    case 'A':
                        salary = 100000;
                        break;
                    case 'B':
                        salary = 80000;
                        break;
                    case 'C':
                        salary = 60000;
                        break;
                    case 'D':
                        salary = 40000;
                        break;
                    case 'E':
                        salary = 20000;
                        break;
                    case 'F':
                        salary = 10000;
                        break;
                    default:
                        Console.WriteLine("Invalid grade. Please enter a grade between A and F.");
                        return;
                }
                if (salary < 10000 || salary > 100000)
                {
                    Console.WriteLine("Invalid salary. Salary must be between 10,000 and 100,000.");
                    return;
                }

                decimal tax;
                decimal netSalary;

                if (salary <= 60000)
                {
                    tax = salary * 0.2m;
                    netSalary = salary - tax;


                }
                else
                {
                    tax = salary * 0.4m;
                    netSalary = salary - tax;
                }


                string employeeInfo = $"Name: {name}, ID: {id}, Department: {department}, Grade: {grade}, Salary: {salary}, Tax: {tax}, Net Salary: {netSalary}";
                employees.Add(employeeInfo);
                Console.WriteLine("Employee added successfully.");
            }
           
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
        }



        void displayEmployees()
        {
            Console.WriteLine("Employee List:");
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }

        }

        void searchEmployee()
        {
            try
            {
                Console.WriteLine("Enter employee ID to search:");
                string searchId = Console.ReadLine();
                bool found = false;
                foreach (string employee in employees)
                {
                    if (employee.Contains($"ID: {searchId}"))
                    {
                        Console.WriteLine("Employee found:");
                        Console.WriteLine(employee);
                        found = true;
                        break;
                    }
                   
                }
                if (found == false)
                {
                    Console.WriteLine("Employee with this ID not found.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        


        void removeEmployee()
        {
            try
            {
                Console.WriteLine("Enter employee ID to remove:");
                int id = int.Parse(Console.ReadLine());
                string employeeToRemove = employees.Find(e => e.Contains($"ID: {id}"));
                if (employeeToRemove != null)
                {
                    employees.Remove(employeeToRemove);
                    Console.WriteLine("Employee removed successfully.");
                }
                else
                {
                    Console.WriteLine("Employee with this ID not found.");
                }
                if (employees.Count == 0)
                {
                    Console.WriteLine("No employees to display.");
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        void exit()
        {
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }



        static void Main(string[] args)
        {
           

            Program program = new Program();
            while (true)
            {
               


                Console.Clear();
                try
                {
                    Console.WriteLine("---------------------------------Welcome to the Employee Management System----------------------------");

                    Console.WriteLine("1-add a new employee");

                    Console.WriteLine("2-display all employees");

                    Console.WriteLine("3-search for an employee");

                    Console.WriteLine("4- remove employee");

                    Console.WriteLine("5-exit");

                    Console.WriteLine("Enter your choice:");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            program.addEmployee();
                            break;
                        case 2:
                            program.displayEmployees();
                            break;
                        case 3:
                            program.searchEmployee();
                            break;
                        case 4:
                            program.removeEmployee();
                            break;
                        case 5:
                            program.exit();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;


                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                
            }
        }
    }
}

