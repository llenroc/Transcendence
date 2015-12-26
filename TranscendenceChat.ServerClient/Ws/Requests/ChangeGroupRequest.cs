using System;
using TranscendenceChat.ServerClient.Entities.Ws.Events;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class ChangeGroupRequest : BaseRequest
    {
        public Guid GroupId { get; set; }

        public string NewGroupName { get; set; }

        public string NewGroupAvatar { get; set; }
    }

    public class ChangeGroupResponse : BaseResponse
    {
    }
}