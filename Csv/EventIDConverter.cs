using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DataExtractor.Csv
{
    internal class EventIDConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text is null || string.IsNullOrEmpty(text.Trim()))
            {
                throw new TypeConverterException(
                this, memberMapData, text, row.Context
                , $"Cannot convert empty cell to EventID");
            }
            text = text.Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
            {
                text = number.ToString("F0", CultureInfo.InvariantCulture);
            }
            var regex = new Regex(@"^\d{12}$");
            if (regex.IsMatch(text))
                return text;
            throw new TypeConverterException(
                this, memberMapData, text, row.Context
                , $"Cannot convert {text} to EventID");
        }
    }
}
