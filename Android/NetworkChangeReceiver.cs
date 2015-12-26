using Android.Content;

namespace TranscendenceChat
{
    public class NetworkChangeReceiver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            await App.ConnectionManager.TryKeepConnectionAsync();
        }
    }
}