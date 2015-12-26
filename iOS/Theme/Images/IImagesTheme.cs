using System;

using UIKit;

namespace TranscendenceChat.iOS
{
	public interface IImagesTheme
	{
		UIImage SignUpIcon { get; }
		UIImage ApplyEffects(UIImage image);
	}
}

