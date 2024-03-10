using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    public static class FilesReader<T>
    {
        public static List<T> Read( string filePath )
        {
            List<T> res;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                ReadingExceptionOccurred = context =>
                {
                    if ( context.Exception is CsvHelper.TypeConversion.TypeConverterException ) {
                        return false;
                    }
                    return true;
                }
            };
            using var reader = new StreamReader(filePath);
            using ( var csv = new CsvReader(reader, config) ) {
                var records = csv.GetRecords<T>();
                res = records.ToList();
            };
            return res;
        }
    }
}
