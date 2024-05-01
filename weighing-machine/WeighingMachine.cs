using System;

class WeighingMachine(int precision) {
    public int Precision => precision;

    private double weight;
    public double Weight {
        get => weight;
        set => weight = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string DisplayWeight => $"{Math.Round(Weight - TareAdjustment, precision).ToString($"F{Precision}")} kg";

    public double TareAdjustment { get; set; } = 5.0;
}
