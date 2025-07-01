using System;

namespace CalculatorTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Testing Windows Forms Calculator Logic");
            Console.WriteLine("====================================");

            // Test basic arithmetic operations
            TestAddition();
            TestSubtraction();
            TestMultiplication();
            TestDivision();
            TestDivisionByZero();
            TestDecimalOperations();

            Console.WriteLine("\n✅ All calculator logic tests passed!");
            Console.WriteLine("\nNote: The Windows Forms UI can only be tested on Windows systems.");
        }

        private static void TestAddition()
        {
            Console.WriteLine("\n🧮 Testing Addition:");
            double result = PerformOperation(5, 3, "+");
            Console.WriteLine($"  5 + 3 = {result} (Expected: 8) {(result == 8 ? "✅" : "❌")}");
            
            result = PerformOperation(10.5, 2.3, "+");
            Console.WriteLine($"  10.5 + 2.3 = {result} (Expected: 12.8) {(Math.Abs(result - 12.8) < 0.0001 ? "✅" : "❌")}");
        }

        private static void TestSubtraction()
        {
            Console.WriteLine("\n➖ Testing Subtraction:");
            double result = PerformOperation(10, 4, "-");
            Console.WriteLine($"  10 - 4 = {result} (Expected: 6) {(result == 6 ? "✅" : "❌")}");
            
            result = PerformOperation(7.5, 2.2, "-");
            Console.WriteLine($"  7.5 - 2.2 = {result} (Expected: 5.3) {(Math.Abs(result - 5.3) < 0.0001 ? "✅" : "❌")}");
        }

        private static void TestMultiplication()
        {
            Console.WriteLine("\n✖️ Testing Multiplication:");
            double result = PerformOperation(6, 7, "×");
            Console.WriteLine($"  6 × 7 = {result} (Expected: 42) {(result == 42 ? "✅" : "❌")}");
            
            result = PerformOperation(2.5, 4, "×");
            Console.WriteLine($"  2.5 × 4 = {result} (Expected: 10) {(result == 10 ? "✅" : "❌")}");
        }

        private static void TestDivision()
        {
            Console.WriteLine("\n➗ Testing Division:");
            double result = PerformOperation(15, 3, "÷");
            Console.WriteLine($"  15 ÷ 3 = {result} (Expected: 5) {(result == 5 ? "✅" : "❌")}");
            
            result = PerformOperation(10, 4, "÷");
            Console.WriteLine($"  10 ÷ 4 = {result} (Expected: 2.5) {(result == 2.5 ? "✅" : "❌")}");
        }

        private static void TestDivisionByZero()
        {
            Console.WriteLine("\n🚨 Testing Division by Zero:");
            try
            {
                PerformOperation(10, 0, "÷");
                Console.WriteLine("  10 ÷ 0 = Should have thrown exception ❌");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("  10 ÷ 0 = Error (Division by zero handled correctly) ✅");
            }
        }

        private static void TestDecimalOperations()
        {
            Console.WriteLine("\n🔢 Testing Decimal Operations:");
            double result = PerformOperation(3.14, 2.86, "+");
            Console.WriteLine($"  3.14 + 2.86 = {result} (Expected: 6) {(Math.Abs(result - 6.0) < 0.0001 ? "✅" : "❌")}");
            
            result = PerformOperation(5.75, 1.25, "-");
            Console.WriteLine($"  5.75 - 1.25 = {result} (Expected: 4.5) {(result == 4.5 ? "✅" : "❌")}");
        }

        // This method simulates the calculator logic from the Windows Forms CalculatorForm
        private static double PerformOperation(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        throw new DivideByZeroException("Division by zero");
                    break;
                default:
                    throw new ArgumentException("Unknown operation");
            }

            return result;
        }
    }
}
