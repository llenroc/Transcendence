using System;

namespace TranscendenceChat
{
    public interface IUIThreadDispacher
    {
        void Dispatch(Action action);
    }
}
