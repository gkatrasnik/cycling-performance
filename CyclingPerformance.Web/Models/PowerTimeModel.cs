namespace CyclingPerformance.Web.Models
{
    public class PowerTimeModel
    {
        public double? Power { get; set; }
        public double? TimeMinutes { get; set; }
        public double? TimeSeconds { get; set; }
        public double MassOfRider { get; set; }
        public double MassOfBike { get; set; }
        public double AirTemperatureCelsius { get; set; }
        public double CdA { get; set; }
        public double Cr { get; set; }
        public double Distance { get; set; }
        public double AltitudeGain { get; set; }
        public double AirTemperatureKelvin => AirTemperatureCelsius + 273.15;

    }
}
