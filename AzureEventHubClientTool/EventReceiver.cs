using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;

namespace AzureEventHubClientTool
{
    public class EventReceiver
    {
        private EventProcessorHost eventProcessorHost;

        public async Task Connect(string hubName, string hubConnStr, string storageName, string storageConnStr)
        {
            this.eventProcessorHost = new EventProcessorHost(
                hubName,
                PartitionReceiver.DefaultConsumerGroupName,
                hubConnStr,
                storageConnStr,
                storageName);

            // Registers the Event Processor Host and starts receiving messages
            await this.eventProcessorHost.RegisterEventProcessorAsync<CustomEventProcessor>();
        }

        public async Task Disconnect()
        {
            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
