using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Owin;
using TranscendenceChat.ServiceBusShared;
using TranscendenceChat.ServiceBusShared.Entities;
using TranscendenceChatServer.Core;
using TranscendenceChatServer.DAL;

[assembly: OwinStartup(typeof(TranscendenceChatServer.Startup))]

namespace TranscendenceChatServer
{
    public partial class Startup
    {
        private const string ConnectionString = "Endpoint=sb://transcendence-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GVFDwh/4b+uCNskMQvG86USdBuK7z1cXcFTkREGlTCc=";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseFileServer(new FileServerOptions()
            {
                RequestPath = new PathString("/Images")
            });

            var messages = new ProcessedMessagesQueue(ConnectionString);
            messages.SubscribeForMessages(OnMessageArrived);
        }

        private bool OnMessageArrived(Message messageDto)
        {
            var userTag = new string[2];

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var result = db.Users.FirstOrDefault(node => node.Id == messageDto.SenderId);
                    userTag[0] = "username:" + messageDto.ReceiverDeviceId;

                    var username = "Some rando";
                    var senderId = 0;
                    if (result != null)
                    {
                        username = result.NickName;
                        senderId = result.Id;
                        result.TranscendencePoints++;
                    }
                    userTag[1] = "from:" + senderId;
                    var push = new PushObject()
                    {
                        Message = username + " has sent you an encrypted message!",
                        FromId = senderId.ToString()
                    };
                    var notification = new Dictionary<string, string> { { "message", JsonConvert.SerializeObject(push) } };
                    //await Notifications.Instance.Hub.SendTemplateNotificationAsync(notification, userTag);
                    //await db.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                // TODO: Log error.
            }

            return true;
        }

        private class PushObject
        {
            public string Message { get; set; }

            public string FromId { get; set; }
        }
    }
}
