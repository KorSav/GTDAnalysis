using DataExtractor.Csv;
using DataExtractor.Records;

namespace DataExtractor
{
    internal static class DataSourceReader
    {
        public static List<WarningRecord> ReadWarning( string filePath )
        {
            return Csv.Reader<WarningRecord>.Read(filePath, "\t");
        }

        public static List<GeneralRecord> ReadGeneral( string filePath )
        {
            return Csv.Reader<GeneralRecord>.Read(filePath, ",");
        }

        public static List<PoisoningRecord> ReadPoisoning( string filePath )
        {
            return Csv.Reader<PoisoningRecord>.Read(filePath, ";");
        }

        public static List<IncidentRecord> ReadIncident( string filePath )
        {
            return Xl.Reader.Read(filePath);
        }

    }
}
