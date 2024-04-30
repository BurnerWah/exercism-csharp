using System;
using System.Linq;

class BirdCount {
    private readonly int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => Array.Exists(birdsPerDay, birds => birds == 0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => Array.FindAll(birdsPerDay, birds => birds >= 5).Length;
}
