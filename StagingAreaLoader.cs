using DataExtractor.Records;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    internal class StagingAreaLoader: IDisposable
    {
        public string ServerName { get; private set; }
        public string DbName { get; private set; }
        private SqlConnection _connection;

        public StagingAreaLoader(string serverName, string dbName )
        {
            ServerName = serverName;
            DbName = dbName;
            _connection = new SqlConnection(
                $"Data Source={serverName};" +
                $"Initial Catalog={dbName};" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True"
                );
            _connection.Open();
        }

        public void Load<T>(List<T> records, string dbTableName )
        {
            var dt = ConvertToDataTable<T>(records);
            using (SqlBulkCopy bulkCopy = new( _connection)) {
                bulkCopy.DestinationTableName = dbTableName;
                bulkCopy.WriteToServer(dt);
            }
        }

        private DataTable ConvertToDataTable<T>( List<T> records )
        {
            PropertyDescriptorCollection props = TypeDescriptor
                .GetProperties( typeof( T ) );
            var dt = new DataTable();
            foreach ( PropertyDescriptor prop in props) {
                dt.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach ( T record in records ) {
                DataRow row = dt.NewRow();
                foreach ( PropertyDescriptor prop in props ) {
                    row[prop.Name] = prop.GetValue(record) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public void Dispose( )
        {
            _connection.Dispose( );
        }
    }
}
