namespace CyclingPerformance.Web.Models
{
    public class CadenceCalculatorModel
    {
        public int[] Chainrings { get; set; } = [];
        public int[] Sprockets { get; set; } = [];
        public double RimDiameter { get; set; }
        public double TireThickness { get; set; }
        public int CadenceFrom { get; set; }
        public int CadenceTo { get; set; }
        public int CadenceStep { get; set; }
    }
}
