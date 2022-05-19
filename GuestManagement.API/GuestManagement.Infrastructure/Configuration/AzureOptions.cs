namespace GuestManagement.Infrastructure.Configuration
{
    public class AzureOptions
    {
        public bool Enabled { get; set; }
        
        public AzureStorageOptions AzureStorageOptions { get; set; }

        public AzureCosmosDbOptions AzureCosmosDbOptions { get; set; }

        public AzureEventHubOptions AzureEventHubOptions { get; set; }
        
        
    }
}