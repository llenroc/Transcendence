using System;
using Microsoft.ServiceBus.Messaging;
using TranscendenceChat.ServiceBusShared;
using TranscendenceChat.ServiceBusShared.Entities;
using TranscendenceChat.WorkerRole.SocketServer.Domain;

namespace TranscendenceChat.WorkerRole.SocketServer.Infrastructure.Transport.InternalBus.ServiceBus
{
    public class InternalMessagesQueue : IInternalMessageBus
    {
        private readonly ServiceBusTopic _serviceBus;
        private const string QueueName = "InternalMessagesQueue";

        public InternalMessagesQueue(string connectionString, string serverInstanceName)
        {
            _serviceBus = new ServiceBusTopic();
            _serviceBus.Initialize(QueueName, "TranscendenceChatWorkerRole", string.Format("To = '{0}'", serverInstanceName), connectionString);
            _serviceBus.MessageReceived += OnMessageReceived;
        }

        public event Action<Event> EventReceived = delegate { };

        public async void Send(Event e, string instanceName)
        {
            var brokeredMsg = new BrokeredMessage(e);
            brokeredMsg.Properties.Add("To", instanceName);
            await _serviceBus.SendAsync(brokeredMsg).ConfigureAwait(false);
        }

        private void OnMessageReceived(BrokeredMessage msg)
        {
            msg.Complete();
            EventReceived(msg.GetBody<Message>());
        }
    }
}
