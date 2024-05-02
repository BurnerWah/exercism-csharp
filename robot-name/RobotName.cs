using System;
using System.Collections.Generic;

public class Robot {
    public static HashSet<string> names = new HashSet<string>();

    public Robot() => Name = GenerateName();

    public string Name { get; private set; }

    public void Reset() {
        var newName = GenerateName();
        names.Remove(Name);
        Name = newName;
    }

    private static string GenerateName() {
        var rng = new Random();
        string newName;
        do {
            newName = $"{(char)rng.Next('A', 'Z' + 1)}{(char)rng.Next('A', 'Z' + 1)}{rng.Next(1000):D3}";
        } while (names.Contains(newName));
        names.Add(newName);
        return newName;
    }
}
