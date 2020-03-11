using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureEventHubClientTool
{
    public class EventSender
    {
        public static async Task SendMessageAsync(string message, string connectionString)
        {
            EventHubsConnectionStringBuilder connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString);
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            EventData eventData = new EventData(Encoding.UTF8.GetBytes(message));

            await eventHubClient.SendAsync(eventData);
            await eventHubClient.CloseAsync();
        }
    }
}
