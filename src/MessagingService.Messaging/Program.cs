using MessagingService.AzureQueue;
using MessagingService.Core;
using MessagingService.Queue;
using Ninject;
using System;
using System.Collections.Generic;

namespace MessagingService.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            //composition 
            var kernel = new StandardKernel();
            kernel.Bind<IQueue>().To<Handler>();

            var messagesList = MakeMeSomeFakeData(0);
            var handler = kernel.Get<IQueue>();
            handler.Enqueue(messagesList);

            var message = new Message();
            while(message != null)
            {
                message = handler.Dequeue();
            }


            Console.WriteLine($"Dequeued: {message.Content}");
            Console.ReadLine();
        }

        private static IEnumerable<Message> MakeMeSomeFakeData(int howMany)
        {
            var messages = new List<Message>();
            for (int i = 0; i < howMany; i++)
            {
                var message = new Message() { Content = "Message ID:" + i };
                messages.Add(message);
            }
            return messages;

        }
    }
}
