using System;
using System.Linq;

public static class Isogram {
    public static bool IsIsogram(string word) {
        var filteredWord = word.Replace("-", null).Replace(" ", null).ToLower();
        var characters = filteredWord.ToHashSet();
        return characters.Count == filteredWord.Length;
    }
}
