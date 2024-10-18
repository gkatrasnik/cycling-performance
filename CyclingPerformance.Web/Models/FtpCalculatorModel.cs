using System.ComponentModel.DataAnnotations;

namespace CyclingPerformance.Web.Models
{
    public class FtpCalculatorModel
    {
        [Range(1, double.MaxValue, ErrorMessage = "FTP 1 must be greater than 1")]

        public double FTP { get; set; }
    }
}
