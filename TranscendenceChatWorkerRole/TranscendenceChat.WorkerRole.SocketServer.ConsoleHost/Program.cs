using System;
using System.Threading;
using TranscendenceChat.WorkerRole.SocketServer;
using TranscendenceChat.WorkerRole.SocketServer.Infrastructure.Logging;
using TranscendenceChat.WorkerRole.SocketServer.Infrastructure.Logging.Loggers;

namespace WorkerRoleConsoleHost
{
    class Program
    {
        private static int port;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter port to host websockets (0 for default & single instance):");
                port = int.Parse(Console.ReadLine());

                LogFactory.Initialize(name => new ConsoleLogger(name));
                ThreadPool.QueueUserWorkItem(_ => Initialize());
                Console.ReadKey();
                Bootstrapper.Stop();
            }
            catch (Exception ex)
            {
                var test = ex;
            }
        }

        private static async void Initialize()
        {
            if (port == 0)
            {
                Bootstrapper.RunInSingleInstanceMode(serverName: "Server", port: 6102,
                    commonServiceBusConnectionString: "Endpoint=sb://transcendence-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GVFDwh/4b+uCNskMQvG86USdBuK7z1cXcFTkREGlTCc=",
                    connections: 1000);
                return;
            }
            Bootstrapper.RunInMultiInstanceMode(serverName: "Server" + port, port: port,
                redisSessionsConnectionString: "transcendence.redis.cache.windows.net,password=NzKn2UR5+B34SBaRA2nOSVstP6AbjmaUG3DZS93agC8=,syncTimeout=10000",
                redisEventsConnectionString: "transcendence.redis.cache.windows.net,password=NzKn2UR5+B34SBaRA2nOSVstP6AbjmaUG3DZS93agC8=,syncTimeout=10000",
                internalServiceBusConnectionString: "Endpoint=sb://transcendence-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GVFDwh/4b+uCNskMQvG86USdBuK7z1cXcFTkREGlTCc=",
                commonServiceBusConnectionString: "Endpoint=sb://transcendence-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GVFDwh/4b+uCNskMQvG86USdBuK7z1cXcFTkREGlTCc=",
                connections: 1000);
        }
    }
}
