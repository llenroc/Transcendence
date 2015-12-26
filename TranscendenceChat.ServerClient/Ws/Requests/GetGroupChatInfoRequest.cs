using System;
using System.Collections.Generic;
using TranscendenceChat.ServerClient.Ws.Entities;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class GetGroupChatInfoRequest : BaseRequest
    {
        public Guid GroupId { get; set; }
    }

    public class GetGroupChatInfoResponse : BaseResponse
    {
        public GroupInfo GroupInfo { get; set; }
    }
}