using System;

namespace CalculatorTest
{
    // This class simulates the exact UI interaction to test for the reported bug
    public class CalculatorUISimulator
    {
        private string displayText = "0";
        private string currentInput = "";
        private string operation = "";
        private double firstNumber = 0;
        private bool isOperationPerformed = false;

        public string DisplayText => displayText;

        public void SimulateNumberButton(string buttonText)
        {
            if (displayText == "0" || isOperationPerformed)
            {
                displayText = "";
                isOperationPerformed = false;
            }
            
            displayText += buttonText;
            currentInput = displayText;
        }

        public void SimulateOperationButton(string operationText)
        {
            if (currentInput != "")
            {
                if (operation != "" && !isOperationPerformed)
                {
                    PerformCalculation();
                }
                else
                {
                    firstNumber = double.Parse(currentInput);
                }
                
                operation = operationText;
                isOperationPerformed = true;
                currentInput = "";
            }
        }

        public void SimulateDecimalButton()
        {
            if (isOperationPerformed)
            {
                displayText = "0";
                isOperationPerformed = false;
            }
            
            if (!displayText.Contains("."))
            {
                displayText += ".";
            }
            
            currentInput = displayText;
        }

        public void SimulateEqualsButton()
        {
            if (operation != "" && currentInput != "")
            {
                PerformCalculation();
                operation = "";
                isOperationPerformed = true;
            }
        }

        public void SimulateClearButton()
        {
            displayText = "0";
            currentInput = "";
            operation = "";
            firstNumber = 0;
            isOperationPerformed = false;
        }

        private void PerformCalculation()
        {
            if (!double.TryParse(currentInput, out double secondNumber))
            {
                displayText = "Error";
                currentInput = "";
                operation = "";
                isOperationPerformed = false;
                return;
            }

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
                    {
                        displayText = "Error: Division by zero";
                        currentInput = "";
                        operation = "";
                        isOperationPerformed = false;
                        return;
                    }
                    break;
                default:
                    return;
            }

            displayText = result.ToString();
            firstNumber = result;
            currentInput = result.ToString();
        }

        public void PrintDebugState(string step)
        {
            Console.WriteLine($"{step}: Display='{displayText}', CurrentInput='{currentInput}', FirstNumber={firstNumber}, Operation='{operation}', IsOperationPerformed={isOperationPerformed}");
        }
    }
}