namespace CyclingPerformance.Web.Models
{
    public class FtpZoneModel
    {
        public string Zone { get; }
        public string Description { get; }
        public string RangeAbsolute { get; }
        public string RangeRelative { get; }

        public FtpZoneModel(string zone, string description, string rangeAbsolute, string rangeRelative)
        {
            Zone = zone;
            Description = description;
            RangeAbsolute = rangeAbsolute;
            RangeRelative = rangeRelative;
        }
    }
}
