namespace CyclingPerformance.Web.Services
{
    public interface ICriticalPowerCalculationService
    {
        double CalculateM(double t1, double t2, double t3, double p1, double p2, double p3);
        double CalculateCP(double m, double t1, double t2, double t3, double p1, double p2, double p3);
        double CalculatePowerAt(double m, double cp, double timeInSeconds);
        double CalculateFtpFromCp(double cp);
    }
}
