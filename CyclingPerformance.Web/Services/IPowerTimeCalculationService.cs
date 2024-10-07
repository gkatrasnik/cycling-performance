namespace CyclingPerformance.Web.Services
{
    public interface IPowerTimeCalculationService
    {
        double CalculateAirDensity(double airTemperature);
        double CalculateRollingResistance(double massOfBike, double massOfRider, double cr);
        double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider);
        double CalculateAirResistance(double velocity, double cda, double airDensity);
        double CalculateVelocity(double distance, double timeInMinutes);
        double CalculateTimeInSeconds(double distance, double velocity);
        double CalculateTotalPower(double velocity, double rollingResistance, double slopeForce, double airResistance);
        double CalculateRequiredPower(double velocity, double rollingResistance, double slopeForce, double cda, double airDensity);
        double CalculateAeroDragCoefficient(double cda, double airDensity);
        double NewtonMethod(double cda, double rollingResistance, double slopePullForce, double power);
        double MsToKmh(double velocityMs);
    }
}
