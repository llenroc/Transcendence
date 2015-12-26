using System;
using System.Collections.Generic;
using TranscendenceChat.ServiceBusShared.Entities;

namespace TranscendenceChat.WorkerRole.SocketServer.Domain
{
    public interface IUndeliveredEventsRepository<TEvent> where TEvent : Event
    {
        List<TEvent> GetAll(string receiverDeviceId);

        void Add(TEvent e);

        List<TEvent> DeleteAll(string deviceId, IEnumerable<Guid> eventIds);
    }
}
