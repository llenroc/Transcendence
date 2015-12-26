using System;
using System.Collections.Generic;
using TranscendenceChat.ServerClient.Entities.Ws.Events;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class MessageReceivedStatusAcknowledgeRequest : BaseRequest
    {
        public List<Guid> Messages { get; set; }
    }
}