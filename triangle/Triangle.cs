using System;

public static class Triangle {
    public static bool IsScalene(double side1, double side2, double side3) => true switch {
        _ when side1 + side2 < side3 => false,
        _ when side2 + side3 < side1 => false,
        _ when side1 + side3 < side2 => false,
        _ => side1 != side2 && side2 != side3 && side3 != side1,
    };

    public static bool IsIsosceles(double side1, double side2, double side3) => true switch {
        _ when side1 + side2 < side3 => false,
        _ when side2 + side3 < side1 => false,
        _ when side1 + side3 < side2 => false,
        _ => side1 == side2 || side2 == side3 || side3 == side1,
    };

    public static bool IsEquilateral(double side1, double side2, double side3) => side1 > 0 && side1 == side2 && side2 == side3;
}
