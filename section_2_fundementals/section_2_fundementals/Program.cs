using System;
using System.Collections.Generic;

namespace CSharpTraining
{
    class Program
    {
        static void Main()
        {
            // You can uncomment tasks one by one while learning.
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6(1);
            Task7();
            Task8();
            Task9();
            Task10();

            Task15();
            Task16();
            Task17();
            Task18();


            Sum(4, 5);
            Console.ReadKey();
        }

        // =========================================================
        // 🟢 EASY TASKS (1–10)
        // =========================================================

        static void Task1()
        {
            var number = 10;
            var text = "Hello";


            // QUESTION:
            // 1) What are the actual types of 'number' and 'text'?
            //    number : int, text: string
            // 2) Why is 'var' different from C++ 'auto'?
             /*
            •	Scope:
            •	var can only be used for local variables inside methods in C#.
            •	auto can be used for local variables, function return types, and parameters in C++.
            •	Type Inference:
            •	Both infer the type from the right-hand side, but C#'s var always resolves to a specific, known type at compile time.
            •	C++'s auto can deduce references, pointers, and even const-ness, making it more flexible.
            •	Initialization Requirement:
            •	With var, you must initialize the variable at the point of declaration.
            •	With auto, initialization is also required, but the deduced type can be more complex (e.g., auto&, const auto*).
             */

        }

        static void Task2()
        {
            int age = 25;
            string name = "Roman";

            string result = $"{name} is {age} years old";
            Console.WriteLine(result);

            // QUESTION:
            // Why is string interpolation safer than printf-style formatting?
            // String interpolation checks types at compile time, reducing runtime errors.
        }

        static void Task3()
        {
            bool flag = true;

            // QUESTION:
            // Why does this NOT compile in C#?
            // if (flag == 1) { }
            // Answer: In C#, boolean types are strictly separate from numeric types. You cannot compare a bool to an int directly.

            if (flag)
            {
                Console.WriteLine("Flag is true");
            }
        }

        static void Task4()
        {
            if (true)
            {
                int x = 5;
            }

            // QUESTION:
            // Why does this NOT compile?
            // Console.WriteLine(x);
            // Answer: The variable 'x' is scoped to the if block and is not accessible outside of it.
        }

        static void Task5()
        {
            string input = "123";

            bool success = int.TryParse(input, out int value);

            Console.WriteLine($"Success: {success}, Value: {value}");

            // QUESTION:
            // What happens to 'value' if parsing fails?
            // Answer: If parsing fails, 'value' is set to 0 , means the amount of characters parsed.
        }

        static void Task6(int day)
        {
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;
            }

            // QUESTION:
            // Why is switch fall-through restricted in C# compared to C?
            // Answer: C# requires explicit breaks to prevent unintentional fall-through, enhancing code clarity and reducing bugs.
        }

        static void Task7()
        {
            char c = 'א';
            Console.WriteLine(c);

            // QUESTION:
            // Why is char 2 bytes in C#?
            // Answer: C# uses UTF-16 encoding for char, which allows representation of a wide range of Unicode characters, requiring 2 bytes.
        }

        static void Task8()
        {
            int[] arr = { 1, 2, 3, 4 };
            Console.WriteLine(arr.Length);

            // QUESTION:
            // Why is this safer than arrays in C?
            // Answer: C# arrays have built-in bounds checking, preventing out-of-bounds access that can lead to undefined behavior in C.
            // an exception will be thrown if you try to access an invalid index.
        }

        static void Task9()
        {
            int[] numbers = { 1, 2, 3 };

            foreach (int n in numbers)
            {
                // n++; // QUESTION: Why does this NOT modify the array?
                // Answer: In a foreach loop, 'n' is a read-only copy of each element. Modifying 'n' does not affect the original array.
                // To modify the array, use a for loop with indices.
            }
        }

        static void Task10()
        {
            try
            {
                int x = int.Parse("abc");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // QUESTION:
            // Why does C# prefer exceptions over error codes?
            // Answer: Exceptions provide a clear separation of error handling from regular code flow, improving readability and maintainability.
        }

        // =========================================================
        // 🟡 MEDIUM TASKS (11–18)
        // =========================================================

        static bool Divide(int a, int b, out int result)
        {
            if (b == 0)
            {
                result = 0;
                return false;
            }

            result = a / b;
            return true;

            // QUESTION:
            // Why must 'result' be assigned on all paths?
            // C# requires out parameters to be assigned before the method returns to ensure they have a defined value.
            // How is this different from passing pointers in C?
            // In C, pointers can be left uninitialized, leading to undefined behavior if dereferenced without assignment.
        }

        static int Sum(int a, int b)
        {
            return a + b;

            // QUESTION:
            // Why must the return type be explicitly declared?
            // C# is a statically typed language that requires explicit type declarations for clarity and type safety at compile time.

        }

        static int FindMax(int[,] matrix)
        {
            // TODO:
            // Iterate over matrix and find max value
            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }

            return max;

            // QUESTION:
            // How does this differ from int** in C?
            // In C#, a 2D array (int[,]) is a single contiguous block of memory, while int** in C represents an array of pointers to arrays, which can lead to non-contiguous memory allocation and more complex memory management.

        }

        static string DescribeDay(int day) =>
            day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                _ => "Unknown"
            };

        static void Task15()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };
            numbers.Add(4);

            // QUESTION:
            // How does List<T> manage memory compared to C arrays?
            // List<T> in C# automatically resizes and manages memory, providing dynamic array capabilities, while C arrays have a fixed size and require manual memory management.
        }

        static void Task16()
        {
            string input = "42";

            if (int.TryParse(input, out int value))
            {
                Console.WriteLine(value);
            }

            // QUESTION:
            // When should TryParse be preferred over Parse?
            // TryParse should be used when there's a possibility of failure in parsing, as it prevents exceptions and allows for graceful error handling.
        }

        static void Task17()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                    continue;

                if (i == 8)
                    break;

                Console.WriteLine(i);
            }
        }

        static void Task18()
        {
            string s = "Hello";
            s += " World";

            Console.WriteLine(s);

            // QUESTION:
            // What happens in memory when modifying strings?
            // Strings in C# are immutable. When modified, a new string is created in memory, and the reference is updated to point to the new string, while the old string remains unchanged until garbage collected.
        }

        // =========================================================
        // 🔴 HARD TASKS (19–22)
        // =========================================================

        class TodoList
        {
            private List<string> _items = new();

            public void Add(string item)
            {
                // TODO: add item
                _items.Add(item);
            }

            public bool Remove(string item)
            {
                // TODO: remove item if exists       
                return _items.Remove(item);
            }

            public string[] GetAll()
            {
                // TODO: return all items as array
                return _items.ToArray();
            }

            // QUESTION:
            // Why return string[] instead of exposing List<string>?
            // Returning string[] provides a fixed-size snapshot of the items, preventing external modification of the internal List<string>, thus maintaining encapsulation and data integrity.
        }

        static int ParsePositiveInt(string input)
        {
            int value = int.Parse(input);

            if (value <= 0)
                throw new ArgumentException("Must be positive");

            return value;

            // QUESTION:
            // Where should this exception be caught?
        }

        static int SumJagged(int[][] data)
        {
            int sum = 0;

            foreach (var row in data)
                foreach (var value in row)
                    sum += value;

            return sum;

            // QUESTION:
            // Compare memory layout:
            // int[][] vs int[,] vs int** (C)
            // int[][] (jagged array) is an array of arrays, allowing for non-uniform row sizes and separate memory allocations for each sub-array.
            // int[,] (2D array) is a single contiguous block of memory, providing better cache locality and performance for uniform data structures.
            // int** in C is similar to jagged arrays but requires manual memory management and can lead to fragmentation.
            // Jagged arrays offer more flexibility, while 2D arrays provide better performance for fixed-size matrices.
            // C-style int** requires careful handling to avoid memory leaks and dangling pointers.
        }

        static void PrintIfEven(int x)
        {
            if (x % 2 == 0)
            {
                Console.WriteLine("Even");
            }

            Console.WriteLine( x % 2 == 0 ? "EVEN":" ");

            // TASK:
            // Refactor using expression-bodied methods or early return
        }
    }
}
