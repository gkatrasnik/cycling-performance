namespace CyclingPerformance.Web.Services
{
    public class CriticalPowerCalculationService : ICriticalPowerCalculationService
    {
        // times are in seconds
        public double CalculateM(double t1, double t2, double t3, double p1, double p2, double p3)
        {
            return (3 * (t1 * p1 + t2 * p2 + t3 * p3) - ((t1 + t2 + t3) * (p1 + p2 + p3))) /
                   (3 * (t1 * t1 + t2 * t2 + t3 * t3) - (t1 + t2 + t3) * (t1 + t2 + t3));
        }

        public double CalculateCP(double m, double t1, double t2, double t3, double p1, double p2, double p3)
        {
            return (p1 + p2 + p3 - m * (t1 + t2 + t3)) / 3;
        }

        public double CalculatePowerAt(double m, double cp, double timeInSeconds)
        {
            double t = 1 / timeInSeconds; // Reciprocal of time in seconds
            return (m * t + cp);
        }

        public double CalculateFtpFromCp(double cp)
        { 
            return (cp * 0.96); 
        }
    }
}
