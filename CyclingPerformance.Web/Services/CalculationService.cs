using CyclingPerformance.Web.Constants;

namespace CyclingPerformance.Web.Services
{
    public class CalculationService : ICalculationService
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

        public double CalculateAirResistance(double velocity, double airDensity)
        {
            return CalculateAeroDragCoefficient(airDensity) * Math.Pow(velocity, 2);
        }

        public double CalculateVelocity(double distance, double timeInMinutes)
        {
            return distance / (timeInMinutes * 60); 

        }

        public double CalculateTimeInMinutes(double distance, double velocity)
        { 
            return (distance / velocity) / 60;
        }

        public double CalculateTotalPower(double velocity, double rollingResistance, double slopeForce, double airResistance)
        {
            return velocity * (rollingResistance + slopeForce + airResistance);
        }

        public double CalculateRequiredPower(double distance, double time, double rollingResistance, double slopeForce, double airDensity)
        {
            double velocity = CalculateVelocity(distance, time);
            double airResistance = CalculateAirResistance(velocity, airDensity);
            double requiredPower = Math.Round(CalculateTotalPower(velocity, rollingResistance, slopeForce, airResistance) / Physics.DrivetrainEfficiency, 2);
            return requiredPower;
        }

        public double CalculateAeroDragCoefficient(double airDensity)
        {
            return Physics.Cd * Physics.A * 0.5 * airDensity;
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
    }
}
