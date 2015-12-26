using System;

namespace TranscendenceChat.iOS
{
	public interface ISelectableSource
	{
		event EventHandler<NSIndexPathEventArgs> Selected;
	}
}

