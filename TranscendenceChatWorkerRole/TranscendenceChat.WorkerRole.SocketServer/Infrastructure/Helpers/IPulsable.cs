using System;

namespace TranscendenceChat.WorkerRole.SocketServer.Infrastructure.Helpers
{
    public interface IPulsable : IDisposable
    {
        void HandleTimerTick();
    }
}