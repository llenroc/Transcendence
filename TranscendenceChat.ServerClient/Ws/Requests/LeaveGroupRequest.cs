using System;
using TranscendenceChat.ServerClient.Entities.Ws.Requests;

namespace TranscendenceChat.ServerClient.Ws.Requests
{
    public class LeaveGroupRequest : BaseRequest
    {
        public Guid GroupId { get; set; }
    }

    public class LeaveGroupResponse : BaseResponse
    {
    }
}
