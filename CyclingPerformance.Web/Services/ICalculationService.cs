namespace CyclingPerformance.Web.Services
{
    public interface ICalculationService
    {
        double CalculateAirDensity(double airTemperature);
        double CalculateRollingResistance(double massOfBike, double massOfRider);
        double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider);
        double CalculateVelocity(double power, double totalForce, double airDensity);
        double CalculatePower(double velocity, double rollingResistance, double slopePullForce, double airDensity);
    }
}
