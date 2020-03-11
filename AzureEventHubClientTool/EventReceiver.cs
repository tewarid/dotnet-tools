using System;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;

namespace AzureEventHubClientTool
{
    public class EventReceiver
    {
        private const int RECEIVE_TIMEOUT_SECS = 20;

        private EventProcessorHost eventProcessorHost;

        public async Task Connect(string hubName, string hubConnStr, string storageName, string storageConnStr, string consumerGroup)
        {
            this.eventProcessorHost = new EventProcessorHost(
                hubName,
                consumerGroup != string.Empty ? consumerGroup : PartitionReceiver.DefaultConsumerGroupName,
                hubConnStr,
                storageConnStr,
                storageName);

            EventProcessorOptions options = new EventProcessorOptions()
            {
                ReceiveTimeout = TimeSpan.FromSeconds(RECEIVE_TIMEOUT_SECS),
            };

            await this.eventProcessorHost.RegisterEventProcessorAsync<CustomEventProcessor>(options);
        }

        public async Task Disconnect()
        {
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
