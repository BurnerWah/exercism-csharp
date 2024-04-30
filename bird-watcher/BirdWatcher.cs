using System;

class BirdCount {
    private readonly int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() {
        foreach (var day in birdsPerDay) {
            if (day == 0) {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays) {
        var count = 0;
        foreach (var day in birdsPerDay[..numberOfDays]) {
            count += day;
        }
        return count;
    }

    public int BusyDays() {
        var count = 0;
        foreach (var day in birdsPerDay) {
            if (day >= 5) {
                count++;
            }
        }
        return count;
    }
}
