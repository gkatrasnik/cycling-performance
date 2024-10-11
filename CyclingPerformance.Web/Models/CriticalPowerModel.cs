using System.ComponentModel.DataAnnotations;

namespace CyclingPerformance.Web.Models
{
    public class CriticalPowerInputModel
    {
        [Range(1, double.MaxValue, ErrorMessage = "Time 1 must be greater than 1")]
        public double Time1 { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Power 1 must be greater than 1")]
        public double Power1 { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Time 2 must be greater than 1")]
        public double Time2 { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Power 2 must be greater than 1")]
        public double Power2 { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Time 3 must be greater than 1")]
        public double Time3 { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Power 3 must be greater than 1")]
        public double Power3 { get; set; }
    }
}
