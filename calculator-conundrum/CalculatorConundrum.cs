using System;

public static class SimpleCalculator {
    // I am amazed this works
    public static string Calculate(int operand1, int operand2, string operation) => (operation, operand2) switch {
        ("+", _) => $"{operand1} {operation} {operand2} = {SimpleOperation.Addition(operand1, operand2)}",
        ("*", _) => $"{operand1} {operation} {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}",
        ("/", 0) => "Division by zero is not allowed.",
        ("/", _) => $"{operand1} {operation} {operand2} = {SimpleOperation.Division(operand1, operand2)}",
        ("", _) => throw new ArgumentException(nameof(operation)),
        (null, _) => throw new ArgumentNullException(nameof(operation)),
        (_, _) => throw new ArgumentOutOfRangeException(nameof(operation)),
    };
}
