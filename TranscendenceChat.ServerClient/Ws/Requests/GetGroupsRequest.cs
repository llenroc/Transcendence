using System;
using System.Collections.Generic;
using TranscendenceChat.ServerClient.Ws.Entities;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class GetGroupsRequest : BaseRequest
    {
    }

    public class GetGroupsResponse : BaseResponse
    {
        public List<GroupInfo> Groups { get; set; } 
    }
}