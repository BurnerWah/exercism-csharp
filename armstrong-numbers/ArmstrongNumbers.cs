using System;
using System.Linq;

public static class ArmstrongNumbers {
    public static bool IsArmstrongNumber(int number) {
        var str = number.ToString();
        var sum = 0;
        foreach (var digit in str) {
            sum += (int)Math.Pow(Int32.Parse(digit.ToString()), str.Length);
        }
        return number == sum;
    }
}
