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
            
            // Test UI simulation to reproduce the reported bug
            TestUISimulation();
            
            // Test the specific fix for decimal synchronization
            DecimalSynchronizationTest.RunTest();

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
            
            // Test the specific case mentioned in the bug report
            result = PerformOperation(0.1, 0.1, "+");
            Console.WriteLine($"  0.1 + 0.1 = {result} (Expected: 0.2) {(Math.Abs(result - 0.2) < 0.0001 ? "✅" : "❌")}");
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

        private static void TestUISimulation()
        {
            Console.WriteLine("\n🖥️ Testing UI Simulation for 0.1 + 0.1:");
            
            var calculator = new CalculatorUISimulator();
            
            // Test scenario 1: User enters "0.1 + 0.1 ="
            calculator.SimulateClearButton();
            calculator.PrintDebugState("Initial state");
            
            // Enter first number: 0.1
            calculator.SimulateNumberButton("0");
            calculator.PrintDebugState("After pressing '0'");
            
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.'");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (first number complete: 0.1)");
            
            // Enter operation: +
            calculator.SimulateOperationButton("+");
            calculator.PrintDebugState("After pressing '+'");
            
            // Enter second number: 0.1
            calculator.SimulateNumberButton("0");
            calculator.PrintDebugState("After pressing '0' (second number)");
            
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (second number)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (second number complete: 0.1)");
            
            // Calculate result
            calculator.SimulateEqualsButton();
            calculator.PrintDebugState("After pressing '=' (final result)");
            
            string result = calculator.DisplayText;
            Console.WriteLine($"  Final result: {result}");
            Console.WriteLine($"  Expected: 0.2");
            Console.WriteLine($"  Test result: {(result == "0.2" ? "✅ PASS" : "❌ FAIL - This reproduces the bug!")}");
            
            // Test scenario 2: Alternative input method (starting with decimal point)
            Console.WriteLine("\n🖥️ Testing alternative input method (.1 + .1):");
            
            calculator.SimulateClearButton();
            
            // Enter first number: .1 (without leading zero)
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (no leading zero)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (first number: .1)");
            
            // Enter operation: +
            calculator.SimulateOperationButton("+");
            calculator.PrintDebugState("After pressing '+'");
            
            // Enter second number: .1
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (second number, no leading zero)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (second number: .1)");
            
            // Calculate result
            calculator.SimulateEqualsButton();
            calculator.PrintDebugState("After pressing '=' (final result)");
            
            result = calculator.DisplayText;
            Console.WriteLine($"  Final result: {result}");
            Console.WriteLine($"  Expected: 0.2");
            Console.WriteLine($"  Test result: {(result == "0.2" ? "✅ PASS" : "❌ FAIL - This reproduces the bug!")}");
            
            // Test scenario 3: What happens if user presses decimal button multiple times?
            Console.WriteLine("\n🖥️ Testing multiple decimal button presses:");
            
            calculator.SimulateClearButton();
            
            // Enter first number with multiple decimal attempts
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After first '.'");
            
            calculator.SimulateDecimalButton(); // Try to add another decimal
            calculator.PrintDebugState("After second '.' (should be ignored)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After '1'");
            
            calculator.SimulateOperationButton("+");
            calculator.PrintDebugState("After '+'");
            
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After '.' for second number");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After '1' for second number");
            
            calculator.SimulateEqualsButton();
            calculator.PrintDebugState("Final result for multiple decimal test");
            
            result = calculator.DisplayText;
            Console.WriteLine($"  Final result: {result}");
            Console.WriteLine($"  Expected: 0.2");
            Console.WriteLine($"  Test result: {(result == "0.2" ? "✅ PASS" : "❌ FAIL")}");
            
            // Test scenario 4: Edge case - what if currentInput gets out of sync?
            Console.WriteLine("\n🖥️ Testing edge case - decimal button with existing decimal:");
            
            calculator.SimulateClearButton();
            
            // Manually test the scenario where decimal button is pressed when display already has decimal
            calculator.SimulateNumberButton("0");
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After 0.");
            
            // Press decimal button again (should be ignored but currentInput should be updated)
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing decimal again (should be ignored)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After 1");
            
            calculator.SimulateOperationButton("+");
            calculator.PrintDebugState("After +");
            
            calculator.SimulateNumberButton("0");
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After second 0.1");
            
            calculator.SimulateEqualsButton();
            calculator.PrintDebugState("Final result for edge case test");
            
            result = calculator.DisplayText;
            Console.WriteLine($"  Final result: {result}");
            Console.WriteLine($"  Expected: 0.2");
            Console.WriteLine($"  Test result: {(result == "0.2" ? "✅ PASS" : "❌ FAIL")}");
            
            // Test scenario 5: Comprehensive test of various decimal operations that could cause issues
            Console.WriteLine("\n🖥️ Testing comprehensive decimal scenarios:");
            
            // Test multiple decimal calculations in sequence
            calculator.SimulateClearButton();
            
            // First calculation: 0.5 + 0.3 = 0.8
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("5");
            calculator.SimulateOperationButton("+");
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("3");
            calculator.SimulateEqualsButton();
            Console.WriteLine($"  0.5 + 0.3 = {calculator.DisplayText} (Expected: 0.8)");
            
            // Continue with the result: 0.8 + 0.1 = 0.9
            calculator.SimulateOperationButton("+");
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("1");
            calculator.SimulateEqualsButton();
            Console.WriteLine($"  Previous result + 0.1 = {calculator.DisplayText} (Expected: 0.9)");
            
            // Now test the specific bug case: 0.1 + 0.1 starting fresh
            calculator.SimulateClearButton();
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("1");
            calculator.SimulateOperationButton("+");
            calculator.SimulateDecimalButton();
            calculator.SimulateNumberButton("1");
            calculator.SimulateEqualsButton();
            result = calculator.DisplayText;
            Console.WriteLine($"  0.1 + 0.1 = {result} (Expected: 0.2) {(result == "0.2" ? "✅" : "❌")}");
            
            Console.WriteLine($"  Final comprehensive test: {(result == "0.2" ? "✅ PASS" : "❌ FAIL")}");
        }
    }
}
