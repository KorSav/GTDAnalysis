﻿using CsvHelper.Configuration.Attributes;

namespace DataExtractor
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
