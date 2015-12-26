using System;
using TranscendenceChat.ServiceBusShared.Entities;
using TranscendenceChat.WorkerRole.SocketServer.Domain;

namespace TranscendenceChat.WorkerRole.SocketServer.Infrastructure.Transport.InternalBus.Stub
{
    /// <summary>
    /// for standalone mode
    /// </summary>
    public class StubInternalMessageBus : IInternalMessageBus
    {
        public void Send(Event e, string targetInstanceName)
        {
        }

        public event Action<Event> EventReceived = delegate { };
    }
}
