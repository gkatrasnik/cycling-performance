namespace CyclingPerformance.Web.Services
{
    public class CadenceCalculationService: ICadenceCalculationService
    {
        public double CalculateSpeed(double developmentMeters, double cadence)
        {
            return CalculateSpeedKmh(developmentMeters, cadence); // In km/h
        }

        public double CalculateGearRatio(double chainring, double sprocket)
        {
            return chainring / sprocket;
        }

        // Calculate development meters (distance traveled per pedal revolution)
        // RimDiameter is in mm and TireThickness is also in mm
        public double CalculateDevelopmentMeters(double gearRatio, double tireThickness, double rimDiameter)
        {
            var wheelDiameterMeters = (rimDiameter + 2 * tireThickness) / 1000.0;
            var wheelCircumference = Math.PI * wheelDiameterMeters;
            return gearRatio * wheelCircumference;
        }

        public double CalculateSpeedKmh(double developmentMeters, double cadence)
        {
            var speedMetersPerMinute = developmentMeters * cadence;
            var speedKilometersPerHour = (speedMetersPerMinute * 60) / 1000;
            return speedKilometersPerHour;
        }
    }
}
