# Windows Forms Calculator

A simple calculator application built with C# and Windows Forms.

## Features

- Basic arithmetic operations: Addition (+), Subtraction (-), Multiplication (×), Division (÷)
- Decimal point support
- Clear function to reset the calculator
- Error handling for division by zero
- User-friendly graphical interface

## Requirements

- .NET 8.0 or later
- Windows operating system (Windows Forms requires Windows)

## How to Build and Run

1. Make sure you have .NET 8.0 SDK installed on your Windows machine
2. Navigate to the Calculator directory
3. Build the project:
   ```
   dotnet build
   ```
4. Run the application:
   ```
   dotnet run
   ```

## Usage

1. Click on number buttons (0-9) to enter numbers
2. Click on operation buttons (+, -, ×, ÷) to select an operation
3. Enter the second number
4. Click the equals button (=) to see the result
5. Use the Clear button (C) to reset the calculator
6. Use the decimal point button (.) to enter decimal numbers

## Project Structure

- `Calculator.csproj` - Project configuration file
- `Program.cs` - Application entry point
- `CalculatorForm.cs` - Main calculator logic
- `CalculatorForm.Designer.cs` - Windows Forms designer-generated code

## Note

This is a Windows Forms application and requires Windows to run. It cannot be executed on Linux or macOS systems.