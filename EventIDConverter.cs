using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    internal class EventIDConverter: DefaultTypeConverter
    {
        public override object ConvertFromString( string text, IReaderRow row, MemberMapData memberMapData )
        {
            var regex = new Regex(@"^\d{12}$");
            if (regex.IsMatch(text))
                return base.ConvertFromString(text, row, memberMapData);
            throw new TypeConverterException(
                this, memberMapData, text, row.Context
                , $"Cannot convert {text} to {memberMapData.Member.Name}");
        }
    }
}
