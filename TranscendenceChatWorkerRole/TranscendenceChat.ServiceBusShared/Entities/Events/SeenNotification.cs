using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscendenceChat.ServiceBusShared.Entities
{
    [Serializable]
    public class SeenNotification : Event
    {
        public Guid MessageToken { get; set; }
    }
}
