using System;
using System.Text;
using System.Threading.Tasks;
using GuestManagement.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GuestManagement.Infrastructure.Services.Messages
{
    public class RabbitMQMessageSender : MessageSender
    {
        private readonly IConfiguration configuration;

        private IConnection connection;
        private IModel channel;
        private ILogger<RabbitMQMessageSender> logger;

        private RabbitMQOptions rabbitMQOptions;



        public RabbitMQMessageSender(IConfiguration configuration,
        ILogger<RabbitMQMessageSender> logger)
        {
            this.logger = logger;
            rabbitMQOptions = configuration.GetSection("Features:RabbitMQOptions")
            .Get<RabbitMQOptions>();

            ConfigureConnection(configuration);
        }

        private void ConfigureConnection(IConfiguration configuration)
        {

            var factory = new ConnectionFactory();

            factory.UserName = rabbitMQOptions.UserName;
            factory.Password = rabbitMQOptions.Password;
            factory.VirtualHost = rabbitMQOptions.Vhost;
            factory.HostName = rabbitMQOptions.Hostname;

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        private void EnsureQueueDeclared(string queueName)
        {

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }



        public override Task SendMessageAsync(string message, string topicOrQueueName)
        {
            EnsureQueueDeclared(topicOrQueueName);
            var body = Encoding.UTF8.GetBytes(message);

            try
            {

                channel.BasicPublish(exchange: "",
                                    routingKey: $"{topicOrQueueName}",
                                    basicProperties: null,
                                    body: body
               );

            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }



            return Task.CompletedTask;

        }

        ~RabbitMQMessageSender()
        {

            try
            {
                connection?.Close();
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Error while closing RabbitMQ connection: {ex.Message}");
                throw;
            }

        }


    }
}