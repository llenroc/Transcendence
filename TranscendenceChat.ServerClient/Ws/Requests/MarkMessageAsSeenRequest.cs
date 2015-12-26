using System;
using System.Collections.Generic;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class MarkMessageAsSeenRequest : BaseRequest
    {
        public long MessagesAuthor { get; set; }

        public List<Guid> MessagesSeen { get; set; } 
    }

    public class MarkMessageAsSeenResponse : BaseResponse
    {
    }
}
