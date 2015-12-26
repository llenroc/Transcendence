using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TranscendenceChatServer.DAL;
using TranscendenceChatServer.Models;
using TranscendenceChatServer.Tools;

namespace TranscendenceChatServer.Controllers
{
    [Authorize]
    public class AvatarController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IQueryable<Avatar> GetAvatars()
        {
            return _db.Avatars.Where(node => node.Type != AvatarType.User);
        }
    }
}
