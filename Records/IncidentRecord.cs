using CsvHelper.Configuration.Attributes;
using DataExtractor.Csv;

namespace DataExtractor.Records
{
    internal class IncidentRecord
    {
        [Name("eventid")]
        [TypeConverter(typeof(EventIDConverter))]
        public string EventID { get; set; }

        [Name("gname")]
        public string GroupName { get; set; }

        [Name("gnumber_new")]
        public int GroupCount { get; set; }

        [Index(27)]
        public string TargetTypeName { get; set; }
    }
}
