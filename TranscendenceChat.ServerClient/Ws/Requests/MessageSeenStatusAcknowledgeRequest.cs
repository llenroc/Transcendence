using System;
using System.Collections.Generic;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class MessageSeenStatusAcknowledgeRequest : BaseRequest
    {
        public List<Guid> Messages { get; set; }
    }
}