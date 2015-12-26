using System;
using Foundation;

namespace TranscendenceChat.iOS
{
	public class AddRemoveReplaceEventArgs : EventArgs
	{
		public NSIndexPath[] IndexPaths { get; set; }
	}
}