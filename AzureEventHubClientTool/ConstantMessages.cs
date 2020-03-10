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

        public const string TooltipEventHubConnectionString = "A connection string following the template 'Endpoint=sb://<FQDN>/;SharedAccessKeyName=<KeyName>;SharedAccessKey=<KeyValue>'. Cannot be blank";

        public const string TooltipStorageName = "Name of the as Azure Storage blob dependency used for persistence. Cannot be blank";

        public const string TooltipStorageConnectionString = "A storage connection string following the template 'DefaultEndpointsProtocol=https;AccountName=<STORAGE_ACCOUNT_NAME>;AccountKey=<STORAGE_ACCOUNT_KEY>;EndpointSuffix=core.windows.net'. Cannot be blank";

        public const string ConsumedMessageHeaderTemplate = "Consumed message at offset '{0}' on {1}:";

        public const string SendingMessage = "Sending message...";

        public const string MessageSent = "Message Sent";

        public const string ErrorSendingMessage = "Error while sending message";

        public const string ExceptionDisplayFormat = "{0} : {1}";

        public const string Connecting = "Connecting...";

        public const string Connected = "Connected";

        public const string ErrorConnecting = "Error while connecting";

        public const string Disconnecting = "Disconnecting... (It might take a while)";

        public const string Disconnected = "Disconnected";
    }
}
