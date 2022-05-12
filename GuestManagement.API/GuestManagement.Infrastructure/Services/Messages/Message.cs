
using Microsoft.Extensions.Logging;

namespace GuestManagement.Infrastructure.Services
{
    public class Message<T> : IMessage
    {
        public Message(ILogger<MessageSender> logger)
        {
            this.logger = logger;
        }
        
        public T Body { get; set; }

        public string SingularityHeader
        {

            get { return singularityHeader; }

            set
            {
                singularityHeader = value;
                logger.LogInformation($"Singularity header is {value}");
            }

        }

        private string singularityHeader;

         //TODO: remove logger from here as it's only for debugging singularity header
        private readonly ILogger<MessageSender> logger;
    }
}