using CyclingPerformance.Web.Constants;

namespace CyclingPerformance.Web.Services
{
    public class PowerTimeCalculationService : IPowerTimeCalculationService
    {
        public double CalculateAirDensity(double airTemperature)
        {
            return Physics.p0 * (273 / airTemperature);
        }

        public double CalculateRollingResistance(double massOfBike, double massOfRider, double crr)
        {
            return Physics.g * (massOfBike + massOfRider) * crr;
        }

        public double CalculateSlopePullForce(double altitudeGain, double distance, double massOfBike, double massOfRider)
        {
            return (altitudeGain / distance) * (massOfBike + massOfRider) * Physics.g;
        }

        public double CalculateAirResistance(double velocity, double cda, double airDensity)
        {
            return CalculateAeroDragCoefficient(cda, airDensity) * Math.Pow(velocity, 2);
        }

        public double CalculateVelocity(double distance, double timeInSeconds)
        {
            return distance / timeInSeconds;

        }

        public double CalculateTimeInSeconds(double distance, double velocity)
        {
            return distance / velocity;
        }

        public double CalculateTotalPower(double velocity, double rollingResistance, double slopeForce, double airResistance)
        {
            return velocity * (rollingResistance + slopeForce + airResistance);
        }

        public double CalculateRequiredPower(double velocity, double rollingResistance, double slopeForce, double cda, double airDensity)
        {            
            double airResistance = CalculateAirResistance(velocity, cda, airDensity);
            double requiredPower = Math.Round(CalculateTotalPower(velocity, rollingResistance, slopeForce, airResistance) / Physics.DrivetrainEfficiency);
            return requiredPower;
        }

        public double CalculateAeroDragCoefficient(double cda, double airDensity)
        {
            return cda * 0.5 * airDensity;
        }

        public double NewtonMethod(double cda, double rollingResistance, double slopePullForce, double power)
        {
            double vel = 20; // Initial guess for velocity in m/s
            const int MAX = 10; // Max iterations
            const double TOL = 0.05; // Tolerance for convergence

            double adjustedPower = power * Physics.DrivetrainEfficiency; // Adjust power by drivetrain efficiency

            for (int i = 0; i < MAX; i++)
            {
                double f = vel * (cda * vel * vel + rollingResistance + slopePullForce) - adjustedPower;
                double fp = cda * 3.0 * vel * vel + rollingResistance + slopePullForce;

                double vNew = vel - f / fp;

                if (Math.Abs(vNew - vel) < TOL)
                    return vNew;

                vel = vNew;
            }

            return 0.0; // Failed to converge
        }

        public double MsToKmh(double velocityMs)
        { 
            return Math.Round(velocityMs * 3.6, 2);
        }
    }
}
