using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    internal static class DataSourceReader
    {
        public static List<WarningRecord> ReadWarning(string filePath )
        {
            return CsvReader<WarningRecord>.Read(filePath, "\t");
        }

        public static List<GeneralRecord> ReadGeneral( string filePath )
        {
            return CsvReader<GeneralRecord>.Read(filePath, ",");
        }

        public static List<PoisoningRecord> ReadPoisoning( string filePath )
        {
            return CsvReader<PoisoningRecord>.Read(filePath, ";");
        }

        

    }
}
