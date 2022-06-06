namespace GuestManagement.Infrastructure.Configuration
{
    public class RabbitMQOptions
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Hostname { get; set; }
        public string Vhost { get; set;} 
        public bool Enabled { get; set; }
        
            
    }
}