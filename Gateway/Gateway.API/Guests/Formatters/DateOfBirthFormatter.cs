using System;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;
using System.Text;

namespace Gateway.Guests.Formatters
{
    public class DateOfBirthFormatter : InputFormatter
    {
        public DateOfBirthFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

        }

        protected override bool CanReadType(Type type)
        {
            return typeof(CreateGuestDto).IsAssignableFrom(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {

            var requestBody = context.HttpContext.Request.Body;

            using StreamReader streamReader = new StreamReader(requestBody);
       
            string body = await streamReader.ReadToEndAsync();

            return null;
        }
    }
}
