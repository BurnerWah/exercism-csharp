using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class NucleotideCount {
    public static IDictionary<char, int> Count(string sequence) => Regex.IsMatch(sequence, @"^[ACGT]*$")
        ? (IDictionary<char, int>)new Dictionary<char, int> {
            ['A'] = sequence.Count(c => c == 'A'),
            ['C'] = sequence.Count(c => c == 'C'),
            ['G'] = sequence.Count(c => c == 'G'),
            ['T'] = sequence.Count(c => c == 'T'),
        }
        : throw new ArgumentException(nameof(sequence));
}
