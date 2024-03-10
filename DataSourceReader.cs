using DataExtractor.Csv;
using DataExtractor.Records;

namespace DataExtractor
{
    internal static class DataSourceReader
    {
        public static List<WarningRecord> ReadWarning( string filePath )
        {
            return Reader<WarningRecord>.Read(filePath, "\t");
        }

        public static List<GeneralRecord> ReadGeneral( string filePath )
        {
            return Reader<GeneralRecord>.Read(filePath, ",");
        }

        public static List<PoisoningRecord> ReadPoisoning( string filePath )
        {
            return Reader<PoisoningRecord>.Read(filePath, ";");
        }

        

    }
}
