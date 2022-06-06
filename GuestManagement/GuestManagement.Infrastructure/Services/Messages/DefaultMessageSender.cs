using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GuestManagement.Infrastructure.Services
{
    public class DefaultMessageSender :  MessageSender 
    {
        private readonly ILogger<MessageSender> logger;

        public static Queue<IMessage> messages { get; set; }

        public DefaultMessageSender(ILogger<MessageSender> logger)
        {
            if(messages is null)
            messages = new Queue<IMessage>();
            this.logger = logger;
        }
        public override Task SendMessageAsync(string message, string topicOrQueueName)
        {
               messages.Enqueue(new Message<string>(logger) {Body = message});
            
            return Task.CompletedTask;
        }
    }
}