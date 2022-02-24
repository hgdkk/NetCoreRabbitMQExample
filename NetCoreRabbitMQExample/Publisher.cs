using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreRabbitMQExample
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));

                    Console.WriteLine("{0} written to, \"{1}\".", message, queueName);
                }
            }
        }
    }
}
