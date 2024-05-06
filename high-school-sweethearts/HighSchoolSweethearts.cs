using System;
using System.Globalization;

public static class HighSchoolSweethearts {
    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA,29} ♡ {studentB,-29}";

    public static string DisplayBanner(string studentA, string studentB) => $"""

             ******       ******
           **      **   **      **
         **         ** **         **
        **            *            **
        **                         **
        **     {studentA.Trim()}  +  {studentB.Trim()}     **
         **                       **
           **                   **
             **               **
               **           **
                 **       **
                   **   **
                     ***
                      *

        """;

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours
    ) {
        var culture = new CultureInfo("de-DE");
        return $"{studentA} and {studentB} have been dating since {start.ToString("d", culture.DateTimeFormat)} - that's {hours.ToString("n2", culture.NumberFormat)} hours";
    }
}
