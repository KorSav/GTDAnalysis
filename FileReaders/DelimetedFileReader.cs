using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.FileReaders
{
    public static class DelimetedFileReader<T>
    {
        public static List<T> Read(string filePath, string delimeter)
        {
            List<T> res;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimeter,
                ReadingExceptionOccurred = context =>
                {
                    if (context.Exception is CsvHelper.TypeConversion.TypeConverterException)
                    {
                        return false;
                    }
                    return true;
                },
                MissingFieldFound = null
            };
            using var reader = new StreamReader(filePath);
            using (var csv = new CsvReader(reader, config))
            {
                res = csv.GetRecords<T>().ToList();
            };
            return res;
        }
    }
}
