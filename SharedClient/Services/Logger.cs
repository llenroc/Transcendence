using System;
using Xamarin;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace TranscendenceChat
{
	public class Logger
	{
		public void Report(Exception ex, IDictionary extraData = null, Insights.Severity warningLevel = Insights.Severity.Warning)
		{
			Debug.WriteLine ("Transcendence: Exception occurred: " + ex); 

			if(!Insights.IsInitialized)
				return;
			
			Insights.Report (ex, extraData, warningLevel);

		}

		public void Track (string trackIdentifier, IDictionary<string, string> table = null)
		{
			Debug.WriteLine ("Transcendence: Event:" + trackIdentifier); 

			if(!Insights.IsInitialized)
				return;
			
			Insights.Track (trackIdentifier, table);
		}

		public IDisposable TrackTimeContext (string identifier)
		{
			var handler = Insights.TrackTime (identifier);
            return new DisposableContext(handler.Start, handler.Stop);
		}
	}
}

