using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscendenceChat.ServiceBusShared.Entities
{
    [Serializable]
    public class NewDeviceCreatedEvent : Event
    {
        public long UserId { get; set; }

        public string DeviceId { get; set; }
    }
}
