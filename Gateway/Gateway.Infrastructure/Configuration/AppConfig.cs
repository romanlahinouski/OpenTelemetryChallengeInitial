using Microsoft.Extensions.Configuration;

namespace Gateway.Infrastructure.Configuration
{
    public class AppConfig
    {
        private static AzureOptions azureOptions = default;

        private static ConnectionStrings connectionStrings = default;


        private static void MapAppConfig(IConfiguration configuration){
            
            azureOptions = configuration.GetSection("AzureOptions").Get<AzureOptions>();

            connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
        }

        public AppConfig(IConfiguration configuration)
        {
            MapAppConfig(configuration);
        }

        public static AzureOptions GetAzureOptions(){
            return azureOptions;
        }

        public static ConnectionStrings GetConnectionStrings(){
            return connectionStrings;
        }


    }
}