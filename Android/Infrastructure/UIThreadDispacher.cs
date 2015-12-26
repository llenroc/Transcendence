using System;

namespace TranscendenceChat.Infrastructure
{
    public class UIThreadDispacher : IUIThreadDispacher
    {
        public void Dispatch(Action action)
        {
            BaseActivity.CurrentActivity.RunOnUiThread(action);
        }
    }
}