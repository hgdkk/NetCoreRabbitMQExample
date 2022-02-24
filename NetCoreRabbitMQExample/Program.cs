using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace NetCoreRabbitMQExample
{
    class Program
    {
        private static readonly string _queueName = "QueueExample";
        private static Publisher _publisher;
        private static Consumer _consumer;
        static void Main(string[] args)
        {
            _publisher = new Publisher(_queueName, "Hello RabbitMQ World!");

            _consumer = new Consumer(_queueName);
            
        }


    }
}
