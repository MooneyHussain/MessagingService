using MessagingService.Core;
using System.Collections.Generic;

namespace MessagingService.Queue
{
    public interface IQueue
    {
        void Enqueue(IEnumerable<Message> message);
        Message Dequeue();
    }
}
