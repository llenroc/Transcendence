using SQLite;
using TranscendenceChat.ServerClient;
using TranscendenceChat.ServerClient.Entities;

namespace TranscendenceChat
{
	public class AvatarItem : EntityBase
	{
		public AvatarItem ()
		{
		}

		public int AvatarId { get; set; }
		public string Location { get; set; }
		public AvatarType AvatarType { get; set; }

		[Ignore]
		public string ImageUrl
		{
			get {
				return EndPoints.BaseUrl + Location;
			}
		}
	}
}

