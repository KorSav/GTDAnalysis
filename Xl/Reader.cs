using DataExtractor.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Excel.EPPlus;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using OfficeOpenXml;

namespace DataExtractor.Xl
{
    static class Reader
    {
        public static List<IncidentRecord> Read(string filePath )
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                ReadingExceptionOccurred = context => {
                    if ( context.Exception is CsvHelper.TypeConversion.TypeConverterException ) {
                        return false;
                    }
                    return true;
                },
                MissingFieldFound = null,
                HasHeaderRecord = false
            };
            var res = new List<IncidentRecord>();
            using ( var reader = new CsvReader(
                new ExcelParser(filePath, configuration: config)) ) {
                res = reader.GetRecords<IncidentRecord>().ToList();
            }
            return res;
        }
    }
}
