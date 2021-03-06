﻿// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using TranscendenceChat.iOS;
using CoreGraphics;

namespace TranscendenceChat.iOS
{
	public partial class IncomingCell : BubbleCell
	{
		static readonly UIImage normalBubbleImage;
		static readonly UIImage highlightedBubbleImage;

		public static readonly NSString CellId = new NSString("Incoming");

		static IncomingCell()
		{
			var cap = new UIEdgeInsets {
				Top = 17,
				Left = (float)26.5,
				Bottom = (float)17.5,
				Right = 21,
			};

			var border = UIImage.FromBundle ("bubble_stroked_mirror");
			var bubble = UIImage.FromBundle ("bubble_regular_mirror");

			normalBubbleImage = CreateBubbleWithBorder(bubble, Theme.Current.BackgroundColor, border, Theme.Current.IncomingBubbleStroke).CreateResizableImage (cap);

			var highlightedColor = UIColor.FromRGB (206, 206, 210);
			highlightedBubbleImage = CreateBubbleWithBorder(bubble, highlightedColor, border, Theme.Current.IncomingBubbleStroke).CreateResizableImage (cap);
		}

		public IncomingCell (IntPtr handle)
			: base (handle)
		{
			Initialize ();
		}

		public IncomingCell ()
		{
			Initialize ();
		}

		void Initialize ()
		{
			BubbleHighlightedImage = highlightedBubbleImage;
			BubbleImg = normalBubbleImage;

			ContentView.AddConstraint (Layout.PinLeftEdge (ContentView, BubbleView));
			ContentView.AddConstraints (NSLayoutConstraint.FromVisualFormat ("V:|-2-[bubble]-2-|",
				NSLayoutFormatOptions.DirectionLeftToRight,
				"bubble", BubbleView
			));
			BubbleView.AddConstraint (Layout.WidthMin (BubbleView, 48));

			var vSpaceTop = NSLayoutConstraint.Create (MessageLbl, NSLayoutAttribute.Top, NSLayoutRelation.Equal, BubbleView, NSLayoutAttribute.Top, 1, 10);
			ContentView.AddConstraint (vSpaceTop);

			var vSpaceBottom = NSLayoutConstraint.Create (MessageLbl, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleView, NSLayoutAttribute.Bottom, 1, -10);
			ContentView.AddConstraint (vSpaceBottom);

			var msgLeading = NSLayoutConstraint.Create (MessageLbl, NSLayoutAttribute.Leading, NSLayoutRelation.GreaterThanOrEqual, BubbleView, NSLayoutAttribute.Leading, 1, 16);
			ContentView.AddConstraint (msgLeading);

			var msgCenter = NSLayoutConstraint.Create (MessageLbl, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleView, NSLayoutAttribute.CenterX, 1, 3);
			ContentView.AddConstraint (msgCenter);
		}

		static UIImage CreateBubbleWithBorder(UIImage bubbleImg, UIColor bubbleColor, UIImage borderImg, UIColor borderColor)
		{
			bubbleImg = CreateColoredImage (bubbleColor, bubbleImg);
			borderImg = CreateColoredImage (borderColor, borderImg);

			CGSize size = bubbleImg.Size;
			UIEdgeInsets caps = CenterPointEdgeInsetsForImageSize (size);

			UIGraphics.BeginImageContextWithOptions (size, false, 0);
			var rect = new CGRect (CGPoint.Empty, size);
			bubbleImg.Draw (rect);
			borderImg.Draw (rect);

			var result = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			result = result.CreateResizableImage (caps);
			return result;
		}

		static UIEdgeInsets CenterPointEdgeInsetsForImageSize (CGSize size)
		{
			CGPoint p = new CGPoint (size.Width / 2f, size.Height / 2f);
			return new UIEdgeInsets (p.Y, p.X, p.Y, p.X);
		}
	}
}
