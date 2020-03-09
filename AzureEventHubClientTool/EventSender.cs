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
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString);
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
            await eventHubClient.CloseAsync();
        }
    }
}
