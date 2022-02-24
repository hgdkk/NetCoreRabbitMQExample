using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreRabbitMQExample
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    
                    consumer.Received += (model, ea) =>
                    {                     
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                         
                        Console.WriteLine("{0} named queue consumes this message: \"{1}\"", queueName, message);
                    };

                    channel.BasicConsume(queueName, true, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
