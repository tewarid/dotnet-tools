using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureEventHubClientTool
{
    public class CustomReceivedData
    {
        public PartitionContext PartitionContext { get; set; }

        public EventData EventData { get; set; }

        public Exception Exception { get; set; }
    }

    public class CustomEventProcessor : IEventProcessor
    {
        public static EventHandler<CustomReceivedData> OnEventReceived;

        public static EventHandler<CustomReceivedData> OnErrorProcessed;

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
            CustomReceivedData data = new CustomReceivedData()
            { 
                PartitionContext = context,
                Exception = error,
            };

            OnErrorProcessed?.Invoke(this, data);
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (EventData eventData in messages)
            {
                CustomReceivedData data = new CustomReceivedData()
                {
                    PartitionContext = context,
                    EventData = eventData,
                };

                OnEventReceived?.Invoke(this, data);
            }

            return context.CheckpointAsync();
        }
    }
}
