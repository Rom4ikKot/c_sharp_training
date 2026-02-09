using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSharpTraining
{
    // =========================
    // CLASSES USED BY TASKS
    // =========================

    public class User
    {
        private int _age;

        public int Age
        {
            get
            {
                
                return _age;
            }
            set
            {
                if(value < 0)
                {
                    _age = 0;
                }
                else
                {
                    _age = value;
                }
            }
        }
    }

    // expression-bodied method example
    public class MathUtils
    {
        
        /*
        public int Square(int x)
        {
            return x * x;
        }
        */
        public int Square(int x) => x * x;
    }

    public class Product
    {
        public string Name { get; }
        public double Price { get; }

        public Product(string name, double price)
        {
            if(string.IsNullOrEmpty(name))
            {
                Name = "";
            }
            else
            {
                Name = name;
            }
            Price = price;
        }
    }

    //optional parameters example
    public class Logger
    {
        public void Log(string message, string level = "INFO")
        {
            Console.WriteLine($"[{level}] {message}");
        }
    }

    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            
            this.x = x;
            this.y = y;
        }
    }

    //readonly field and static constructor example
    public class Config
    {
        public const int MaxUsers = 100;
        public readonly Guid Id;

        // TODO: initialize Id
        public Config()
        {
            Id = Guid.NewGuid();
        }
    }

    //object initializer example
    public class Car
    {
        public string Brand { get; set; }
        public int Year { get; set; }
    }

    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        // TODO: overload Add for double
        public double Add(double a, double b) => a + b;
    }

    public class TemperatureConverter
    {
        // TODO: make static
        /*
        public double CelsiusToFahrenheit(double c)
        {
            return c * 9 / 5 + 32;
        }
        */
        public static double CelsiusToFahrenheit(double c) => c * 9 / 5 + 32;
    }

    public class CsvUtils
    {

        /*
         * public string ReverseCsv(string csv)
         {
            // TODO: split by ',', reverse, join back
            return "";
         }
         * 
         */
        public string ReverseCsv(string csv)
        {
            return string.Join(",", csv.Split(',').Reverse());
        }
    }

    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        // TODO: computed property Area
        public double Area => Width * Height;
    }

    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        // Task 12: Constructor chaining
        public Person(string name) : this(name, 0) { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Task: Static constructor
    public class IdGenerator
    {
        public static int LastId;
        /*
         A static constructor in C# is used to initialize static fields or perform actions that need to occur only once for a class, before any static members are accessed or any instances are created.
            Key reasons to use a static constructor:
        •	Initialize static fields: If you have static fields that require complex initialization (not just a simple assignment), a static constructor is the right place.
        •	One-time setup: It runs only once, automatically, before the class is used for the first time.
        •	No parameters: Static constructors cannot take parameters and cannot be called directly.
         Here, the static constructor ensures that LastId is set to 1000 before any code accesses IdGenerator.LastId. This guarantees consistent, one-time initialization.
        Summary:
        Use a static constructor when you need to set up static data or perform actions that should happen only once for the class, regardless of how many objects are created.

         */

        // TODO: static constructor to initialize LastId = 1000
        static IdGenerator()
        {
            LastId = 1000;
        }
    }

    public class BankAccount
    {
        private double _balance;

        public void Deposit(double amount) => _balance += amount;

        // TODO: replace GetBalance() with property
        public double GetBalance()
        {
            return _balance;
        }
        public double Balance => _balance;
    }


    // Property with private setter
    public class SecureAccount
    {
        public string Owner { get; }
        public double Balance { get; private set; }

        public SecureAccount(string owner)
        {
            Owner = owner;
        }

        /*
         public void Deposit(double amount)
        {
 
        }
        */
        public void Deposit(double amount)
        {
            if (amount > 0)
                Balance += amount;
        }
    }

    // Task 19: Immutability
    public class Vector2
    {
        public double X { get; }
        public double Y { get; }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        // TODO: make immutable and implement Add(Vector2 other)
        public Vector2 Add(Vector2 other)
        {
            return new Vector2(X + other.X, Y + other.Y);
        }
    }

    // =========================
    // TASK RUNNER
    // =========================

    class Program
    {
        static void Main()
        {
            Task1_UserAge();
            Task2_Square();
            Task3_Product();
            Task4_Logger();
            Task5_Point();
            Task6_Config();
            Task7_Car();
            Task8_Calculator();
            Task9_Temperature();
            Task10_Csv();
            Task11_Rectangle();
            Task12_Person();
            Task13_IdGenerator();
            Task14_BankAccount();
           
           
            Task17_SecureAccount();
            Task18_Vector2();
            Console.ReadKey();
        }

        static void PrintTitle(string name)
        {
            Console.WriteLine("\n====================");
            Console.WriteLine(name);
            Console.WriteLine("====================");
        }

        // ---------- EASY TASKS ----------

        static void Task1_UserAge()
        {
            PrintTitle("Task 1 - User Age Validation");

            var user = new User();
            user.Age = -5;
            Console.WriteLine("Age set to -5 (should fail?)");
            user.Age = 150;
            Console.WriteLine("Age set to 150 (should fail?)");
            user.Age = 30;
            Console.WriteLine("Valid age set: " + user.Age);
        }

        static void Task2_Square()
        {
            PrintTitle("Task 2 - Square");
            var m = new MathUtils();
            Console.WriteLine("Square(5) = " + m.Square(5));
        }

        static void Task3_Product()
        {
            PrintTitle("Task 3 - Product");

           
            var p = new Product("", -10);
            Console.WriteLine($"{p.Name} - {p.Price}");
            var p2 = new Product("Laptop", 5000);
            Console.WriteLine($"{p2.Name} - {p2.Price}");
        }

        static void Task4_Logger()
        {
            PrintTitle("Task 4 - Logger");
            var logger = new Logger();
            logger.Log("Hello");
            logger.Log("Error occurred", "ERROR");
        }

        static void Task5_Point()
        {
            PrintTitle("Task 5 - Point");
            var p = new Point(3, 4);
            Console.WriteLine($"Point: {p.x}, {p.y}");
        }

        static void Task6_Config()
        {
            PrintTitle("Task 6 - Config");
            var c = new Config();
            Console.WriteLine("MaxUsers = " + Config.MaxUsers);
            Console.WriteLine("Id = " + c.Id);
        }

        static void Task7_Car()
        {
            PrintTitle("Task 7 - Car Object Initializer");
            var car = new Car { Brand = "Toyota", Year = 2020 };
            Console.WriteLine($"{car.Brand}, {car.Year}");
        }

        static void Task8_Calculator()
        {
            PrintTitle("Task 8 - Calculator");
            var calc = new Calculator();
            Console.WriteLine(calc.Add(2, 3));
            Console.WriteLine(calc.Add(2.5, 3.5));
        }

        static void Task9_Temperature()
        {
            PrintTitle("Task 9 - Temperature");
            Console.WriteLine(TemperatureConverter.CelsiusToFahrenheit(0));
        }

        static void Task10_Csv()
        {
            PrintTitle("Task 10 - CSV");
            var csv = new CsvUtils();
            Console.WriteLine(csv.ReverseCsv("1,2,3,4"));
        }

        // ---------- MEDIUM TASKS ----------

        static void Task11_Rectangle()
        {
            PrintTitle("Task 11 - Rectangle");
            var r = new Rectangle { Width = 3, Height = 4 };
            Console.WriteLine("Area = " + r.Area);
        }

        static void Task12_Person()
        {
            PrintTitle("Task 12 - Person");
            var p1 = new Person("Alice");
            var p2 = new Person("Bob", 25);
            Console.WriteLine($"{p1.Name}, {p1.Age}");
            Console.WriteLine($"{p2.Name}, {p2.Age}");
        }

        static void Task13_IdGenerator()
        {
            PrintTitle("Task 13 - IdGenerator");
            Console.WriteLine(IdGenerator.LastId);
        }

        static void Task14_BankAccount()
        {
            PrintTitle("Task 14 - BankAccount");
            var acc = new BankAccount();
            acc.Deposit(100);
            Console.WriteLine("Balance = " + acc.Balance);
        }

     
        // ---------- HARD TASKS ----------

        static void Task17_SecureAccount()
        {
            PrintTitle("Task 17 - SecureAccount");
            var acc = new SecureAccount("Roman");
            acc.Deposit(100);
            Console.WriteLine("Balance = " + acc.Balance);
        }

        static void Task18_Vector2()
        {
            PrintTitle("Task 18 - Vector2");
            var v1 = new Vector2(1, 2);
            var v2 = new Vector2(3, 4);
            var v3 = v1.Add(v2);
            Console.WriteLine($"({v3.X}, {v3.Y})");
        }
    }
}
