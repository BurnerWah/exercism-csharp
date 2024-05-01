using System;
using System.Linq;

public enum Classification {
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers {
    public static Classification Classify(int number) => number switch {
        <= 0 => throw new ArgumentOutOfRangeException(nameof(number)),
        // An odd number must be at least 945 to be abundant number, so we can
        // skip all te checks there
        < 945 when Int32.IsOddInteger(number) => Classification.Deficient,
        _ => (number - Enumerable.Range(1, number - 1).Where(n => number % n == 0).Sum()) switch {
            > 0 => Classification.Deficient,
            0 => Classification.Perfect,
            < 0 => Classification.Abundant,
        },
    };
}
