using System.Reflection;
using Autofac;
using TranscendenceChat.ServiceBusShared;
using TranscendenceChat.WorkerRole.SocketServer.Api;
using TranscendenceChat.WorkerRole.SocketServer.Api.Base;
using Module = Autofac.Module;

namespace TranscendenceChat.WorkerRole.SocketServer
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccessTokenFastValidator>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(i => i.IsSubclassOf(typeof(BaseController))).AsSelf().SingleInstance();
            base.Load(builder);
        }
    }
}
