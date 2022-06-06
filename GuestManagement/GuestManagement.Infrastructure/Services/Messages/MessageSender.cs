using System;
using System.Threading.Tasks;

namespace GuestManagement.Infrastructure.Services
{
    public abstract class MessageSender
    {
    

        public MessageSender()
        {
           
        }

        public abstract Task SendMessageAsync(string message, string topicOrQueueName);

    }
}