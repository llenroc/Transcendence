using Microsoft.Azure.NotificationHubs;

namespace TranscendenceChatServer.Core
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString(
                "Endpoint=sb://transcendence-notification.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wOHgy6KnfeRHapuy2iiWvOnhb/yJtFTEWBVbRCad+Io=",
                "transcendence-notification");
        }
    }
}
