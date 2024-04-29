using System;

class RemoteControlCar {
    private int _distance = 0;
    private int _battery = 100;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_distance} meters";

    public string BatteryDisplay() => $"Battery {(_battery > 0 ? $"at {_battery}%" : "empty")}";

    public void Drive() {
        if (_battery > 0) {
            _distance += 20;
            _battery -= 1;
        }
    }
}
