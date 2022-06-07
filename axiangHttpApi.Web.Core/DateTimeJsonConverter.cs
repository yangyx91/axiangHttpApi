using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace axiangHttpApi.Web.Core
{
    public class DateTimeJsonConverter: JsonConverter<DateTime>
    {
        private readonly string _dateFormatString;
        public DateTimeJsonConverter()
        {
            _dateFormatString = "yyyy-MM-dd HH:mm:ss";
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            TimeZoneInfo chinaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            DateTime chinaTime = TimeZoneInfo.ConvertTimeFromUtc(value.ToUniversalTime(), chinaTimeZone);
            writer.WriteStringValue(chinaTime.ToString(_dateFormatString));
        }
    }
}
