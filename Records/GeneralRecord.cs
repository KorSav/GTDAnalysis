﻿using CsvHelper.Configuration.Attributes;
using DataExtractor.Csv;

namespace DataExtractor.Records
{
    public class GeneralRecord
    {
        [Name("eventid")]
        [TypeConverter(typeof(EventIDConverter))]
        public string EventID { get; set; }

        [Name("iyear")]
        public int Year { get; set; }

        [Name("imonth")]
        public int Month { get; set; }

        [Name("iday")]
        public int Day { get; set; }

        [Name("country")]
        public int CountryCode { get; set; }

        [Name("country_txt")]
        public string CountryName { get; set; }

        [Name("region")]
        public int RegionCode { get; set; }

        [Name("region_txt")]
        public string RegionName { get; set; }

        [Name("suicide")]
        [TypeConverter(typeof(BooleanConverter))]
        public bool IsSuicide { get; set; }

        [Name("gname")]
        public string GroupName { get; set; }

        [Name("weaptype1_txt")]
        public string WeaponTypeName { get; set; }

        [Name("nkill")]
        public int DeathCount { get; set; }

        [Name("nwound")]
        public int WoundCount { get; set; }
    }
}
