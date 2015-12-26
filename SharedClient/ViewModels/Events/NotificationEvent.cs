using System;

namespace TranscendenceChat
{
	public class NotificationEventArgs : EventArgs
	{
		public string Title { get; set; }
		public string Message { get; set; }
	}
}