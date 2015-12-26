using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TranscendenceChat.ServerClient.Entities;
using TranscendenceChat.ServerClient.Interfaces;

namespace TranscendenceChat.ServerClient.Managers
{
    public class AvatarManager : IAvatarManager
    {
        private readonly IWebManager _webManager;
        public AvatarManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public AvatarManager(string authenticationToken)
            : this(new WebManager(authenticationToken))
        {
        }

        public async Task<List<Avatar>> GetStaticAvatars()
        {
            var uri = new Uri(EndPoints.GetAvatarList);
            var result = await _webManager.GetData(uri);
            return JsonConvert.DeserializeObject<List<Avatar>>(result.ResultJson);
        }
    }
}
