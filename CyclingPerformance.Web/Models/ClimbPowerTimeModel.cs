namespace CyclingPerformance.Web.Models
{
    public class ClimbPowerTimeModel
    {
        public double? Power { get; set; } // Power in Watts
        public double? Time { get; set; } // Time in minutes
        public double MassOfRider { get; set; } // Mass of rider in kg
        public double MassOfBike { get; set; } // Mass of bicycle in kg
        public double AirTemperature { get; set; } // Air temperature in K
        public double Distance { get; set; } // Distance in meters
        public double AltitudeGain { get; set; } // Altitude gain in meters
    }
}
