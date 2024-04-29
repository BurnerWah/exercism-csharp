class Lasagna {
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int t) => ExpectedMinutesInOven() - t;

    public int PreparationTimeInMinutes(int t) => t * 2;

    public int ElapsedTimeInMinutes(int layers, int minutes) => PreparationTimeInMinutes(layers) + minutes;
}
