using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gateway.Application.Guests;
using Gateway.Application.Guests.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gateway.Infrastructure.Guests
{

    public class GuestRestService : IGuestService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly ILogger<GuestRestService> logger;

        public GuestRestService(HttpClient httpClient, IConfiguration configuration, ILogger<GuestRestService> logger)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.logger = logger;
        }


        public async Task CreateGuestAsync(CreateGuestCommand createGuestCommand)
        {
            string serializedCreateGuestCommand = JsonConvert.SerializeObject(createGuestCommand);

            string targetUrl = String.Concat(configuration["ConnectionStrings:GuestManagementService"], "api/Guest/");

            var response = await httpClient.PostAsync(targetUrl, serializedCreateGuestCommand);

            string responseContent = await response.Content.ReadAsStringAsync();
        }


        public async Task RegisterForAVisitAsync(RegisterGuestCommand registerGuestCommand)
        {
            string serializedRegisterGuestCommand = JsonConvert.SerializeObject(registerGuestCommand);

            string targetUrl = String.Concat(configuration["ConnectionStrings:GuestManagementService"], "api/Guest/VisitRegistration");

            await httpClient.PostAsync(targetUrl, serializedRegisterGuestCommand);
        }


        public async Task CancelRegistrationAsync(CancelRegistrationCommand cancelRegistrationCommand)
        {
            // string serializedCancelRegistrationCommand = JsonConvert.SerializeObject(cancelRegistrationCommand);
            // StringContent content = new StringContent(serializedCancelRegistrationCommand, Encoding.UTF8, "application/json");

            // var response = await httpClient.PostAsync(String.Concat(configuration["ConnectionStrings:GuestManagementService"],"api/Guest/"), content);

            // if(!response.IsSuccessStatusCode){
            //     throw new HttpRequestException(response.ReasonPhrase);
            // }
        }

        public async Task<IEnumerable<GuestDto>> GetGuestsAsync(int guestsNumber)
        {
            var response = await httpClient.GetAsync(String.Concat(configuration["ConnectionStrings:GuestManagementService"], "api/Guest/"),
            new Dictionary<string, string>{
                {"numberOfGuests", guestsNumber.ToString()} }
            );

            var stringContent = await response.Content.ReadAsStringAsync();

            var guests = JsonConvert.DeserializeObject<IEnumerable<GuestDto>>(await response.Content.ReadAsStringAsync());

            return guests;
        }
    }

}