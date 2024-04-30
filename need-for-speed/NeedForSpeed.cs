using System;

class RemoteControlCar(int speed, int batteryDrain) {
    private readonly int speed = speed;
    private readonly int batteryDrain = batteryDrain;
    private int battery = 100;
    private int distance = 0;

    public bool BatteryDrained() => battery < batteryDrain;

    public int DistanceDriven() => distance;

    public void Drive() {
        if (!BatteryDrained()) {
            distance += speed;
            battery -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack(int distance) {
    private readonly int distance = distance;

    public bool TryFinishTrack(RemoteControlCar car) {
        while (car.DistanceDriven() < distance) {
            if (car.BatteryDrained()) {
                return false;
            }
            car.Drive();
        }
        return true;
    }
}
