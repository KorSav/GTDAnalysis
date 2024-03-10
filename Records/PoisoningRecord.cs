using CsvHelper.Configuration.Attributes;
using DataExtractor.Csv;

namespace DataExtractor.Records
{
    public class PoisoningRecord
    {
        [Index(0)]
        [TypeConverter(typeof(EventIDConverter))]
        public string EventID { get; set; }

        [Name("IfYes,DeliveryMethod")]
        public string PoisonDeliveryMethod { get; set; }

        [Name("PoisoningAgent1")]
        public string PoisoningAgent { get; set; }

        [Name("ActualorSuspectedExposureRouteEstimatedbyEventDetails" +
            "(dermal/mucosal/ocular,peroral,inhalation,parenteral)")]
        public string ExposureRoute { get; set; }
    }
}
