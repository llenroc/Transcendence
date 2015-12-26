using System;
using TranscendenceChat.ServiceBusShared.Entities;

namespace TranscendenceChat.WorkerRole.SocketServer.Domain
{
    public interface IInternalMessageBus
    {
        void Send(Event e, string targetInstanceName);

        event Action<Event> EventReceived;
    }
}
