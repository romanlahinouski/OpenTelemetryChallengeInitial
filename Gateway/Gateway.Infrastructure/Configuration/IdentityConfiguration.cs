namespace Gateway.Infrastructure.Configuration
{
    public class IdentityConfiguration
    {
        public string ClientId { get; set; }

        public string TenantId { get; set; }

        public bool IsEnabled { get; set; }

        public string Domain { get; set; }

        public string Instance { get; set; }

        public Group [] AllowedGroups { get; set; }
                     
    }
}