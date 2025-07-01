# TestRepo

This repository contains a Windows Forms Calculator application written in C#.

## Projects

### Calculator
A complete Windows Forms calculator application with a graphical user interface. Features:
- Basic arithmetic operations (addition, subtraction, multiplication, division)
- Decimal point support
- Clear functionality
- Error handling for division by zero
- Professional Windows Forms interface

**Requirements:** Windows OS with .NET 8.0 or later

### CalculatorTest
A console application that tests the calculator logic on any platform. This demonstrates that the mathematical operations work correctly even when the Windows Forms UI cannot be displayed.

## Getting Started

### To run the Calculator (Windows only):
```bash
cd Calculator
dotnet build
dotnet run
```

### To test the calculator logic (Any platform):
```bash
cd CalculatorTest
dotnet run
```

## Project Structure
- `Calculator/` - Windows Forms calculator application
- `CalculatorTest/` - Console-based logic testing
- `.gitignore` - Git ignore file for build artifacts