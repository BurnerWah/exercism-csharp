using System;
using System.Linq;

public static class Pangram {
    public static bool IsPangram(string input) => input.ToLower().Distinct().Count(Char.IsLetter) == 26;
}
