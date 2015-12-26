using System;

namespace TranscendenceChat
{
	public class MessageStatusEventArgs : EventArgs
	{
		public Guid MessageToken { get; set; }
		public MessageStatus Status { get; set; }
	}
}

