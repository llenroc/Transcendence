﻿using System;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using TranscendenceChat.ServiceBusShared.Entities;

namespace TranscendenceChat.ServiceBusShared
{
    public class ProcessedMessagesQueue
    {
        private Func<Message, bool> _messageCallback;
        private readonly ServiceBusQueue _serviceBus;
        private const string QueueName = "ProcessedMessagesQueue";
        
        public ProcessedMessagesQueue(string serviceBusConnectionString)
        {
            //create blank queue in case of empty CS
            if (string.IsNullOrEmpty(serviceBusConnectionString))
                return;

            _serviceBus = new ServiceBusQueue();
            _serviceBus.Initialize(QueueName, serviceBusConnectionString);
        }

        public void SubscribeForMessages(Func<Message, bool> messageCallback)
        {
            _messageCallback = messageCallback;
            if (messageCallback != null)
            {
                _serviceBus.MessageReceived += OnMessageReceived;
            }
        }

        public async void Enqueue(Message message)
        {
            if (_serviceBus == null)
                return;

            //fire & forget
            var bm = new BrokeredMessage(JsonConvert.SerializeObject(message));
            bm.ContentType = "text/plain";
            await _serviceBus.SendAsync(bm).ConfigureAwait(false);
        }

        private void OnMessageReceived(BrokeredMessage brokeredMsg)
        {
            var msg = JsonConvert.DeserializeObject<Message>(brokeredMsg.GetBody<string>());
            if (_messageCallback(msg))
            {
                brokeredMsg.Complete();
            }
        }
    }
}
