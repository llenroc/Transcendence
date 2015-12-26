using System;
using TranscendenceChat.ServerClient.Ws.Events;

namespace TranscendenceChat.ServerClient.Entities.Ws.Events
{
    public class DeliveryNotification : PushedEvent
    {
        public Guid EventId { get; set; }

        public Guid MessageToken { get; set; }
        
        public DateTime DeliveredAt { get; set; }
    }
}
