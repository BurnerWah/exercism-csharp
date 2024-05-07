public class RemoteControlCar {
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;
    public CTelemetry Telemetry;

    public RemoteControlCar() => Telemetry = new CTelemetry(this);

    public string GetSpeed() => currentSpeed.ToString();
    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;
    private void SetSpeed(Speed speed) => currentSpeed = speed;

    public class CTelemetry {
        private readonly RemoteControlCar parent;

        protected internal CTelemetry(RemoteControlCar parent) => this.parent = parent;

        public void Calibrate() { }
        public bool SelfTest() => true;
        public void ShowSponsor(string sponsorName) => parent.SetSponsor(sponsorName);
        public void SetSpeed(decimal amount, string unitsString) => parent.SetSpeed(new Speed(
            amount,
            unitsString == "cps" ? SpeedUnits.CentimetersPerSecond : SpeedUnits.MetersPerSecond
        ));
    }

    private readonly struct Speed(decimal amount, SpeedUnits speedUnits) {
        public decimal Amount { get; } = amount;
        public SpeedUnits SpeedUnits { get; } = speedUnits;

        public override string ToString() => $"{Amount} {(SpeedUnits == SpeedUnits.CentimetersPerSecond ? "centimeters" : "meters")} per second";
    }

    private enum SpeedUnits {
        MetersPerSecond,
        CentimetersPerSecond
    }
}




