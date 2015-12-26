using System;
using CoreFoundation;

namespace TranscendenceChat.iOS
{
    public class UiThreadDispacher : IUIThreadDispacher
    {
        public void Dispatch(Action action)
        {
            DispatchQueue.MainQueue.DispatchAsync(action);
        }
    }
}