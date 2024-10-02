using CyclingPerformance.Web.Constants;

namespace CyclingPerformance.Web.Services
{    
    public class CalculationService: ICalculationService
    {
        public double CalculateAirDensity(double airTemperature)
        {
            return Physics.p0 * (273 / airTemperature);
        }

        public double CalculateRollingResistance(double massOfBike, double massOfRider)
        {
            return Physics.g * (massOfBike + massOfRider) * Physics.Cr;
        }

        public double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider)
        {
            return (altitudeGain / distance) * (massOfBike + massOfRider) * Physics.g;
        }

        public double CalculateVelocity(double power, double totalForce, double airDensity)
        {
            return Math.Pow((power + totalForce) / (Physics.Cd * Physics.A * 0.5 * airDensity), 0.5);
        }

        public double CalculatePower(double velocity, double rollingResistance, double slopePullForce, double airDensity)
        {
            return (Physics.Cd * Physics.A * 0.5 * airDensity * Math.Pow(velocity, 3)) + rollingResistance + slopePullForce;
        }
    }    
}
    
