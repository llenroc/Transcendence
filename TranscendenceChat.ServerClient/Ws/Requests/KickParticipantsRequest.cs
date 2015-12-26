using System;
using System.Collections.Generic;

namespace TranscendenceChat.ServerClient.Entities.Ws.Requests
{
    public class KickParticipantsRequest : BaseRequest
    {
        public Guid GroupId { get; set; }

        public List<long> ParticipantIds { get; set; }
    }

    public class KickParticipantsResponse : BaseResponse
    {
    }
}