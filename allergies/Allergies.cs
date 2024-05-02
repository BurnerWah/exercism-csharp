using System;
using System.Collections.Generic;
using System.Linq;

[Flags]
public enum Allergen {
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128,
}

public class Allergies(int mask) {
    private readonly Allergen allergens = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen) => allergens.HasFlag(allergen);

    private static readonly List<Allergen> allergenFlags = [
        Allergen.Eggs,
        Allergen.Peanuts,
        Allergen.Shellfish,
        Allergen.Strawberries,
        Allergen.Tomatoes,
        Allergen.Chocolate,
        Allergen.Pollen,
        Allergen.Cats,
    ];

    public Allergen[] List() => allergenFlags.Where(IsAllergicTo).ToArray();
}
