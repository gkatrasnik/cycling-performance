namespace CyclingPerformance.Web.Models
{
    public class FtpZoneModel
    {
        public string Zone { get; }
        public string Description { get; }
        public string Range { get; }

        public FtpZoneModel(string zone, string description, string range)
        {
            Zone = zone;
            Description = description;
            Range = range;
        }
    }
}
