using System;
using Android.App;
using Android.OS;
using System.IO;
using Plugin.CurrentActivity;
using TranscendenceChat.Infrastructure;

using Environment = System.Environment;

namespace TranscendenceChat
{
	[Application]
	public class TranscendenceApplication: Application, Application.IActivityLifecycleCallbacks
	{
		
		public TranscendenceApplication(IntPtr handle, global::Android.Runtime.JniHandleOwnership transer)
			:base(handle, transer)
		{

		}

		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);

			Xamarin.Insights.Initialize (App.InsightsKey, this);
			Xamarin.Insights.ForceDataTransmission = true;
			ServiceContainer.Register<IMessageDialog> (() => new MessageDialog ());
			var dbLocation = "Transcendence.db3";

			var library = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			dbLocation = Path.Combine(library, dbLocation);
			TranscendenceDatabase.DatabaseLocation = dbLocation;

			ServiceContainer.Register<IUIThreadDispacher>(() => new UIThreadDispacher());
			ServiceContainer.Register<ILiveConnection>(() => new WebSocketConnection());
			App.Init ();
		}

		public override void OnTerminate()
		{
			base.OnTerminate();
			UnregisterActivityLifecycleCallbacks(this);
		}

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityDestroyed(Activity activity)
		{
		}

		public void OnActivityPaused(Activity activity)
		{
		}

		public void OnActivityResumed(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
		}

		public void OnActivityStarted(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityStopped(Activity activity)
		{
		}
	}
}

