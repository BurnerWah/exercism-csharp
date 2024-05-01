using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples {
    public static int Sum(IEnumerable<int> multiples, int max) => (from n in Enumerable.Range(1, max - 1)
                                                                   from m in multiples
                                                                   where m > 0
                                                                   where m < max
                                                                   where n % m == 0
                                                                   select n).Distinct().Sum();
}
