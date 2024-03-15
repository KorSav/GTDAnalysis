using DataExtractor.FileReaders;
using DataExtractor.Records;

namespace DataExtractor
{
    internal static class DataSourceReader
    {
        public static List<WarningRecord> ReadWarning( string filePath )
        {
            return DelimetedFileReader<WarningRecord>.Read(filePath, "\t");
        }

        public static List<GeneralRecord> ReadGeneral( string filePath )
        {
            return DelimetedFileReader<GeneralRecord>.Read(filePath, ",");
        }

        public static List<PoisoningRecord> ReadPoisoning( string filePath )
        {
            return DelimetedFileReader<PoisoningRecord>.Read(filePath, ";");
        }

        public static List<IncidentRecord> ReadIncident( string filePath )
        {
            return ExcelReader.Read(filePath);
        }

    }
}
