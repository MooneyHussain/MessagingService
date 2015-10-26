using MessagingService.Core;
using MessagingService.Queue;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagingService.AzureQueue
{
    public class Handler : IQueue
    {
        private QueueClient _client;
        private OnMessageOptions _options;
        public Handler()
        {
            string connectionString =
              CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            QueueClient Client = QueueClient.CreateFromConnectionString(connectionString, "TestingQueue");

            OnMessageOptions options = new OnMessageOptions();
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            _client = Client;
            _options = options;
        }

        public void Enqueue(IEnumerable<Message> messages)
        {
            //messages.Select(x => new BrokeredMessage { Label = x.Content }).ToList().ForEach(x => _client.Send(x));
            var list = messages.Select(message => new BrokeredMessage
            {
                Label = message.Content
            });

            foreach (var item in list)
            {
                _client.Send(item);
            }
        }

        public Message Dequeue()
        {
            var message = _client.Receive();
            return new Message { Content = message.Label };
        }
    }
}
