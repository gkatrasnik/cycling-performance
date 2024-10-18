using System.ComponentModel.DataAnnotations;

namespace CyclingPerformance.Web.Models
{
    public class PowerTimeModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Power cannot be negative.")]
        public double? Power { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Time (minutes) cannot be negative.")]
        public double? TimeMinutes { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Time (seconds) cannot be negative.")]
        public double? TimeSeconds { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Mass of the rider cannot be negative.")]
        public double MassOfRider { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Mass of the bike cannot be negative.")]
        public double MassOfBike { get; set; }

        public double AirTemperatureCelsius { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "CdA (aerodynamic drag coefficient) cannot be negative.")]
        public double CdA { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Cr (rolling resistance coefficient) cannot be negative.")]
        public double Crr { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Distance cannot be negative.")]
        public double Distance { get; set; }

        public double AltitudeGain { get; set; }

        public double Headwind{ get; set; }

        public double AirTemperatureKelvin => AirTemperatureCelsius + 273.15;
    }
}
