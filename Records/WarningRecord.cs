using CsvHelper.Configuration.Attributes;
using DataExtractor.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Records
{
    internal class WarningRecord
    {
        [Index(0)]
        [TypeConverter(typeof(EventIDConverter))]
        public string EventID { get; set; }

        [Name("Religious")]
        [TypeConverter(typeof(BooleanConverter))]
        public bool IsReligious { get; set; }

        [Name("Warning")]
        [TypeConverter(typeof(BooleanConverter))]
        public bool IsWarned { get; set; }
    }
}
