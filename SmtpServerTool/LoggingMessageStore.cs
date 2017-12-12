using SmtpServer;
using SmtpServer.Mail;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmtpServerTool
{
    internal class LoggingMessageStore : MessageStore
    {
        public event Action<string> Message;

        public override Task<SmtpResponse>
            SaveAsync(ISessionContext context,
            IMessageTransaction transaction,
            CancellationToken cancellationToken)
        {
            ITextMessage textMessage = (ITextMessage)transaction.Message;

            using (var reader = new StreamReader(textMessage.Content, Encoding.UTF8))
            {
                Message.Invoke(reader.ReadToEnd());
            }

            return Task.FromResult(SmtpResponse.Ok);
        }
    }
}
