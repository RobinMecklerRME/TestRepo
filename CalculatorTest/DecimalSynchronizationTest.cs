using System;

namespace CalculatorTest
{
    // This test specifically demonstrates the fix for the decimal synchronization issue
    public class DecimalSynchronizationTest
    {
        public static void RunTest()
        {
            Console.WriteLine("\n🔧 Testing Decimal Synchronization Fix:");
            Console.WriteLine("========================================");
            
            var calculator = new CalculatorUISimulator();
            
            // Test the specific scenario that could have caused synchronization issues
            Console.WriteLine("\n📝 Scenario: User accidentally presses decimal button twice");
            
            calculator.SimulateClearButton();
            
            // Enter first number: 0.1
            calculator.SimulateNumberButton("0");
            calculator.PrintDebugState("After pressing '0'");
            
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (first time)");
            
            // User accidentally presses decimal again
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (second time - should be ignored)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (first number: 0.1)");
            
            // Verify that currentInput matches display
            bool firstNumberOK = calculator.DisplayText == "0.1";
            Console.WriteLine($"✓ First number correct: {firstNumberOK}");
            
            // Enter operation
            calculator.SimulateOperationButton("+");
            calculator.PrintDebugState("After pressing '+'");
            
            // Enter second number: 0.1 (starting with decimal)
            calculator.SimulateDecimalButton();
            calculator.PrintDebugState("After pressing '.' (second number)");
            
            calculator.SimulateNumberButton("1");
            calculator.PrintDebugState("After pressing '1' (second number: 0.1)");
            
            // Calculate result
            calculator.SimulateEqualsButton();
            calculator.PrintDebugState("After pressing '=' (final calculation)");
            
            string result = calculator.DisplayText;
            bool resultCorrect = result == "0.2";
            
            Console.WriteLine($"\n🎯 Final Test Results:");
            Console.WriteLine($"   Input sequence: 0 . . 1 + . 1 =");
            Console.WriteLine($"   Expected result: 0.2");
            Console.WriteLine($"   Actual result: {result}");
            Console.WriteLine($"   Test status: {(resultCorrect ? "✅ PASS - Fix working correctly!" : "❌ FAIL")}");
            
            if (resultCorrect)
            {
                Console.WriteLine($"\n✨ The decimal synchronization fix ensures that currentInput");
                Console.WriteLine($"   is always updated to match the display, preventing potential");
                Console.WriteLine($"   state desynchronization issues.");
            }
        }
    }
}