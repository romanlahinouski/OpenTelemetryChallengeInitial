using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RestaurantGuide.Guests
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader == null)
                throw new ArgumentNullException();

            string? value = (string)reader.Value;

            var info = CultureInfo.CurrentCulture.DateTimeFormat;

            Type type = info.GetType();

            var props = type.GetProperties();

            DateTime dateTime = default;
         
            // foreach (var prop in props)
            // {
            //     if (prop.Name.Contains("Pattern"))
            //     {
            //         string fmt = prop.GetValue(info, null).ToString();

            //         if (DateTime.TryParseExact(value, fmt, null, DateTimeStyles.None, out dateTime))
            //             return dateTime;
            //     }
            // }


            if (DateTime.TryParseExact(value, "dd/MM/yyyy", null, DateTimeStyles.None, out dateTime))
                      return dateTime;
            else
             throw new FormatException("Invalid data format");
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}