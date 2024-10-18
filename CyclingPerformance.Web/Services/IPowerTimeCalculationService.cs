namespace CyclingPerformance.Web.Services
{
    public interface IPowerTimeCalculationService
    {
        double CalculateAirDensity(double airTemperature);
        double CalculateRollingResistance(double massOfBike, double massOfRider, double crr);
        double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider);
        double CalculateAirResistance(double velocity, double cda, double airDensity, double headwind);
        double CalculateVelocity(double distance, double timeInSeconds);
        double CalculateTimeInSeconds(double distance, double velocity);
        double CalculateTotalPower(double velocity, double rollingResistance, double slopeForce, double airResistance);
        double CalculateRequiredPower(double velocity, double rollingResistance, double slopeForce, double cda, double airDensity, double headwind);
        double CalculateAeroDragCoefficient(double cda, double airDensity);
        double CalculateVAM(double ascend, double timeInSeconds);
        double CalculateWkg(double power, double massOfRider);
        double NewtonMethod(double cda, double headwind,double rollingResistance, double slopePullForce, double power);
        double MsToKmh(double velocityMs);
        double KmhToMs(double velocityKmh);
        double ConvertToSeconds(double timeMinutes, double timeSeconds);
    }
}
