using System;

namespace LambdaAndAnonymousMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create lambda operators for arithmetic operations
            Func<int, int, int> Add = (a, b) => a + b;
            Func<int, int, int> Sub = (a, b) => a - b;
            Func<int, int, int> Mul = (a, b) => a * b;
            Func<int, int, int> Div = (a, b) => b == 0 ? throw new DivideByZeroException() : a / b;

            // Get user input for arithmetic operation
            Console.WriteLine("Enter arithmetic operation (Add, Sub, Mul, Div):");
            string operation = Console.ReadLine();

            // Get user input for operands
            Console.WriteLine("Enter first operand:");
            int operand1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second operand:");
            int operand2 = int.Parse(Console.ReadLine());

            // Perform arithmetic operation based on user input
            int result = 0;
            switch (operation)
            {
                case "Add":
                    result = Add(operand1, operand2);
                    break;
                case "Sub":
                    result = Sub(operand1, operand2);
                    break;
                case "Mul":
                    result = Mul(operand1, operand2);
                    break;
                case "Div":
                    try
                    {
                        result = Div(operand1, operand2);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    return;
            }

            Console.WriteLine($"Result: {result}");

            // Create anonymous method to calculate average of delegate method results
            Func<Func<int>, int>[] delegates = new Func<Func<int>, int>[3];
            delegates[0] = delegate { return new Random().Next(1, 11); };
            delegates[1] = delegate { return new Random().Next(11, 21); };
            delegates[2] = delegate { return new Random().Next(21, 31); };

            Func<Func<int>, int> averageDelegate = delegate (Func<int> func)
            {
                int sum = 0;
                for (int i = 0; i < delegates.Length; i++)
                {
                    sum += func();
                }
                return sum / delegates.Length;
            };

            Console.WriteLine($"Average of delegate method results: {averageDelegate(delegates)}");

            // Create anonymous method to calculate average of three integers
            Func<int, int, int, int> averageIntegers = delegate (int a, int b, int c)
            {
                return (a + b + c) / 3;
            };

            Console.WriteLine($"Average of three integers: {averageIntegers(10, 20, 30)}");
        }
    }
}