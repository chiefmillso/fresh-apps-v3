using System;
using Fresh.Core.Logging;

[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.iOS.PlatformLogger))]

namespace WhatDayPCL.iOS
{
	public class PlatformLogger : LoggingFacade, ILogger
	{
		public PlatformLogger () : base (new DebugLogger ())
		{
		}
	}
}

