﻿using System;

namespace TranscendenceChat.ServiceBusShared.Entities
{
    [Serializable]
    public class DeliveryNotification : Event
    {
        public Guid MessageToken { get; set; }
    }
}