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

        public double CalculateAirResistance(double velocity, double cda, double airDensity, double headwind)
        {
            double adjustedVelocity = velocity + headwind;
            return CalculateAeroDragCoefficient(cda, airDensity) * Math.Pow(adjustedVelocity, 2);
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

        public double CalculateRequiredPower(double velocity, double rollingResistance, double slopeForce, double cda, double airDensity, double headwind)
        {
            double airResistance = CalculateAirResistance(velocity, cda, airDensity, headwind);
            double requiredPower = Math.Round(CalculateTotalPower(velocity, rollingResistance, slopeForce, airResistance) / Physics.DrivetrainEfficiency);
            return requiredPower;
        }

        public double CalculateAeroDragCoefficient(double cda, double airDensity)
        {
            return cda * 0.5 * airDensity;
        }

        public double CalculateVAM(double ascend, double timeInSeconds)
        {
            double timeInHours = timeInSeconds / 3600;
            return Math.Round(ascend / timeInHours);
        }

        public double CalculateWkg(double power, double massOfRider)
        { 
            return Math.Round(power / massOfRider, 2);
        }

        public double NewtonMethod(double cda, double headwind, double rollingResistance, double slopePullForce, double power)
        {
            double vel = 20; // Initial guess for velocity in m/s
            const int MAX = 10; // Max iterations
            const double TOL = 0.05; // Tolerance for convergence

            double adjustedPower = power * Physics.DrivetrainEfficiency; // Adjust power by drivetrain efficiency

            for (int i = 0; i < MAX; i++)
            {
                // Calculate air resistance with headwind
                double airResistance = CalculateAirResistance(vel, cda, Physics.p0, headwind);
                double f = vel * (airResistance + rollingResistance + slopePullForce) - adjustedPower;
                double fp = 3.0 * airResistance + rollingResistance + slopePullForce;

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

        public double KmhToMs(double velocityKmh)
        {
            return Math.Round(velocityKmh * 0.2777778, 2);
        }


        public double ConvertToSeconds(double timeMinutes, double timeSeconds)
        {
            return (timeMinutes * 60) + timeSeconds;
        }
    }
}
