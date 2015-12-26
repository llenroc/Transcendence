using System;
using System.Collections.Generic;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class SendIsTypingRequest : BaseRequest
    {
        public List<string> Devices { get; set; }

        public Guid GroupId { get; set; }

        public bool IsTyping { get; set; }
    }
}
