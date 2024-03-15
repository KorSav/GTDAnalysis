using Microsoft.Data.SqlClient;
using System.Globalization;
using CsvHelper;
using DataExtractor;
using CsvHelper.Configuration;
using DataExtractor.Records;

internal class Program
{
    private static void Main( string[] args )
    {
        const string datasetFolder = "C:\\Users\\user\\Desktop\\education\\АДІС\\АД1\\dataset";
        const string file_general = "general.csv";
        const string file_incident = "incident.xlsx";
        const string file_poison = "poison.csv";
        const string file_warning = "warning.tab";

        try {
            List<GeneralRecord> gr = [];
            List<PoisoningRecord> pr = [];
            List<IncidentRecord> ir = [];
            List<WarningRecord> wr = [];

            using ( var sal = new StagingAreaLoader("PC\\SQLSERVER_ADIS", "StagingArea") ) {
                gr = DataSourceReader.ReadGeneral(Path.Combine(datasetFolder, file_general));
                sal.Load(gr, "General");
                Console.WriteLine("General loaded.");

                pr = DataSourceReader.ReadPoisoning(Path.Combine(datasetFolder, file_poison));
                sal.Load(pr, "Poisoning");
                Console.WriteLine("Poisoning loaded.");

                ir = DataSourceReader.ReadIncident(Path.Combine(datasetFolder, file_incident));
                sal.Load(ir, "Incident");
                Console.WriteLine("Incident loaded.");

                wr = DataSourceReader.ReadWarning(Path.Combine(datasetFolder, file_warning));
                sal.Load(wr, "Warning");
                Console.WriteLine("Warning loaded.");

                using SqlCommand cmd = new(
                    "delete from [General] " +
                    "where [Month] = 0 or [Day] = 0"
                    , sal.Connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Empty dates deleted.");
            }
        }
        catch ( SqlException ex ) {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}