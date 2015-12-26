using System;
using UIKit;

namespace TranscendenceChat.iOS
{
	public static class RefresherControl
	{
		public static void ApplyCurrentTheme(UIControl refresher)
		{
			//refresher.BackgroundColor = Theme.Current.MainGradientStartColor;
			refresher.TintColor = UIColor.White;
		}
	}
}

