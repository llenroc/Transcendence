using System;
using TranscendenceChat.ServerClient.Ws.Events;

namespace TranscendenceChat.ServerClient.Entities.Ws.Events
{
    public class SeenNotification : PushedEvent
    {
        public Guid EventId { get; set; }

        public Guid MessageToken { get; set; }
        
        public DateTime SeenAt { get; set; }
    }
}
