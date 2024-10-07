namespace CyclingPerformance.Web.Services
{
    public interface ICalculationService
    {
        double CalculateAirDensity(double airTemperature);
        double CalculateRollingResistance(double massOfBike, double massOfRider);
        double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider);
        double CalculateAirResistance(double velocity, double airDensity);
        double CalculateVelocity(double distance, double timeInMinutes);
        double CalculateTimeInSeconds(double distance, double velocity);
        double CalculateTotalPower(double velocity, double rollingResistance, double slopeForce, double airResistance);
        double CalculateRequiredPower(double distance, double timeInSeconds, double rollingResistance, double slopeForce, double airDensity);
        double CalculateAeroDragCoefficient(double airDensity);
        double NewtonMethod(double cda, double rollingResistance, double slopePullForce, double power);

    }
}
