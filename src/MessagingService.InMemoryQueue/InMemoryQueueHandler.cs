using MessagingService.Core;
using MessagingService.Queue;
using System;
using System.Collections.Generic;

namespace MessagingService.InMemoryQueue
{
    public class MemoryQueueHandler : IQueue
    {
        private Queue<Message> _messagesQueue;

        public MemoryQueueHandler()
        {
            _messagesQueue = new Queue<Message>();
        }

        public void Enqueue(IEnumerable<Message> message)
        {
            foreach (var item in message)
            {
                _messagesQueue.Enqueue(item);
            }
        }

        public Message Dequeue()
        {
            return null;
        }
    }
}
