using System;
using TranscendenceChat.ServerClient.Entities.Ws.Requests;

namespace TranscendenceChat.ServerClient.Ws.Requests
{
    public class GroupChangedAcknowledgeRequest : BaseRequest
    {
        public Guid EventId { get; set; }
    }
}
