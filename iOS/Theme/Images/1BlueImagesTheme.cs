using System;
using UIKit;

namespace TranscendenceChat.iOS
{
	public class BlueImagesTheme : IImagesTheme
	{
		public static BlueImagesTheme Instance { get; private set; }

		static BlueImagesTheme()
		{
			Instance = new BlueImagesTheme ();
		}

		private BlueImagesTheme()
		{
			
		}

		public UIImage SignUpIcon {
			get {
				return UIImage.FromBundle ("inner6Icon");
			}
		}

		public UIImage ApplyEffects (UIImage image)
		{
			return image;
		}
	}
}

