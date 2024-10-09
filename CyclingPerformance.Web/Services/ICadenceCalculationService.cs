namespace CyclingPerformance.Web.Services
{
    public interface ICadenceCalculationService
    {
        double CalculateSpeed(double developmentMeters, double cadence);
        double CalculateGearRatio(double chainring, double sprocket);
        double CalculateDevelopmentMeters(double gearRatio, double tireThickness, double rimDiameter);
        double CalculateSpeedKmh(double developmentMeters, double cadence);
    }
}
