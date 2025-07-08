using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private string currentInput = "";
        private string operation = "";
        private double firstNumber = 0;
        private bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (displayTextBox.Text == "0" || isOperationPerformed)
            {
                displayTextBox.Text = "";
                isOperationPerformed = false;
            }
            
            displayTextBox.Text += btn.Text;
            currentInput = displayTextBox.Text;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
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
                
                operation = btn.Text;
                isOperationPerformed = true;
                currentInput = "";
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (operation != "" && currentInput != "")
            {
                PerformCalculation();
                operation = "";
                isOperationPerformed = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            displayTextBox.Text = "0";
            currentInput = "";
            operation = "";
            firstNumber = 0;
            isOperationPerformed = false;
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed)
            {
                displayTextBox.Text = "0";
                isOperationPerformed = false;
            }
            
            if (!displayTextBox.Text.Contains("."))
            {
                displayTextBox.Text += ".";
            }
            
            currentInput = displayTextBox.Text;
        }

        private void PerformCalculation()
        {
            if (!double.TryParse(currentInput, out double secondNumber))
            {
                displayTextBox.Text = "Error";
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
                        displayTextBox.Text = "Error: Division by zero";
                        currentInput = "";
                        operation = "";
                        isOperationPerformed = false;
                        return;
                    }
                    break;
                default:
                    return;
            }

            displayTextBox.Text = result.ToString();
            firstNumber = result;
            currentInput = result.ToString();
        }
    }
}