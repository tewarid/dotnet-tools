using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureEventHubClientTool
{
    public class CustomEventProcessor : IEventProcessor
    {
        public static EventHandler<EventData> OnEventReceived;

        public static EventHandler<Exception> OnErrorProcessed;

        public Task OpenAsync(PartitionContext context)
        {
            return Task.CompletedTask;
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            OnErrorProcessed?.Invoke(this, error);
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (EventData eventData in messages)
            {
                OnEventReceived?.Invoke(this, eventData);
            }

            return context.CheckpointAsync();
        }
    }
}
