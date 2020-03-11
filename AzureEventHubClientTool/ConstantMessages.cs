using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureEventHubClientTool
{
    public static class ConstantMessages
    {
        public const string TooltipEventHubName = "Name of the Event Hub, specific to the namespace that contains it. Cannot be blank";

        public const string TooltipEventHubConnectionString = "A connection string following the template:\n'Endpoint=sb://<FQDN>/;SharedAccessKeyName=<KeyName>;SharedAccessKey=<KeyValue>'\nCannot be blank";

        public const string TooltipStorageName = "Name of the as Azure Storage blob dependency used for persistence. Cannot be blank";

        public const string TooltipStorageConnectionString = "A storage connection string following the template:\n'DefaultEndpointsProtocol=https;AccountName=<STORAGE_ACCOUNT_NAME>;AccountKey=<STORAGE_ACCOUNT_KEY>;EndpointSuffix=core.windows.net'\nCannot be blank";

        public const string TooltipConsumerGroup = "Name of the consumer group. If blank, uses Default group";

        public const string ConsumedMessageHeaderTemplate = "Consumed event [partition='{0}', offset='{1}'] at {2}:";

        public const string SendingMessage = "Sending message...";

        public const string MessageSent = "Message Sent";

        public const string ErrorSendingMessage = "Error while sending message";

        public const string ExceptionDisplayFormat = "{0} : {1}";

        public const string Connecting = "Consumer Connecting...";

        public const string Connected = "Consumer Connected";

        public const string ErrorConnecting = "Error while connecting";

        public const string Disconnecting = "Consumer Disconnecting... (It might take a while)";

        public const string Disconnected = "Consumer Disconnected";
    }
}
