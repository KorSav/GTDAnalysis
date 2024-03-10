using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace DataExtractor
{
    internal class BooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString( string text, IReaderRow row, MemberMapData memberMapData )
        {
            if ( text is null || string.IsNullOrEmpty( text.Trim() ) ) {
                throw new TypeConverterException(
                this, memberMapData, text, row.Context
                , $"Cannot convert empty cell to boolean");
            }
            text = text.Replace(',', '.');
            if ( double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double number) ) {
                text = number.ToString("F0", CultureInfo.InvariantCulture);
            }
            if ( text == "1" ) {
                return true;
            }
            if ( text == "0" ) { 
                return false; 
            }

            throw new TypeConverterException(
                this, memberMapData, text, row.Context
                , $"Cannot convert {text} to boolean");
        }
    }
}
