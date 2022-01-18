using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sumOfNumbers = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"The sum of the numbers is: {sumOfNumbers}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"The average of the numbers is: {average}");
            Console.WriteLine("------------------------------------------");


            //Order numbers in ascending order and decsending order. Print each to console.
            var ascendingOrder = numbers.OrderBy(num => num);
            var decendingOrder = numbers.OrderByDescending(num => num);

            Console.WriteLine("Ascending Order:");
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Decending Order:");
            foreach (var number in decendingOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------------------------------");

            //Print to the console only the numbers greater than 6
            var onlySix = numbers.Where(x => x > 6);

            Console.WriteLine("Only Numbers Greater Than Six:");
            foreach (var number in onlySix)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------------------------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Printing Only 4 Numbers:");
            foreach (var num in numbers.OrderByDescending(x => numbers).Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------------------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Replacing Index 4 with my age:");
            numbers.SetValue(30, 4);
            foreach (var num in numbers.OrderBy(num => num))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------------------------");



            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Printed Only If Name Starts With C or S");
            var filtered = employees.Where(person => person.FirstName.ToLower()[0] == 'c' || person.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName);
            foreach (var person in filtered)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine("------------------------------------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Ordered by age over 26");
            var overTwentySix = employees.Where(x => x.Age > 26).OrderBy(x => x.FirstName);
            foreach (var item in overTwentySix)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("------------------------------------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            int sum = employees.Sum(num => num.YearsOfExperience);
            var averageYOE = employees.Average(person => person.YearsOfExperience);
            Console.WriteLine($"Sum of years of experience is {sum}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Average of years of experience is {averageYOE}");
            Console.WriteLine("------------------------------------------");

            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("YOE Less than or Equal to 10 AND Age is Greater Than 35");
            var withParameters = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            foreach (var item in withParameters)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("------------------------------------------");

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Printing all names, including my own.");
            employees = employees.Append(new Employee("Jacob", "Crowe", 30, 1)).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("------------------------------------------");


            Console.WriteLine();

            Console.ReadLine();


            
        }
        #region CreateEmployeesMethod
        public static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}