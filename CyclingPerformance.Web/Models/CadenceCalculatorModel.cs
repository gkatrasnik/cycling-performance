using System.ComponentModel.DataAnnotations;

namespace CyclingPerformance.Web.Models
{
    public class CadenceCalculatorModel
    {
        public int[] Chainrings { get; set; } = Array.Empty<int>();
        public int[] Sprockets { get; set; } = Array.Empty<int>();

        [Range(0, double.MaxValue, ErrorMessage = "Rim Diameter cannot be negative.")]
        public double RimDiameter { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Tire Thickness cannot be negative.")]
        public double TireThickness { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cadence cannot be negative.")]
        public int CadenceFrom { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cadence cannot be negative.")]
        public int CadenceTo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cadence must be positive.")]
        public int CadenceStep { get; set; }
    }
}
