using Fresh.Core.Logging;
using Fresh.Core.Contracts;
using System.Collections.Generic;
using Fresh.Core.Xamarin;
using Autofac;
using Fresh.Core.Xamarin.Contracts;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.iOS.PlatformLogger))]
[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.iOS.ModulesProvider))]

namespace WhatDayPCL.iOS
{
	public class PlatformLogger : LoggingFacade, ILogger
	{
		public PlatformLogger () : base (new DebugLogger ())
		{
		}
	}

	public class ModulesProvider : IModulesProvider
	{
		public IContainerModule[] Provide ()
		{
			var list = new List<IContainerModule> ();
			list.Add (new iOSModule ());
			return list.ToArray ();
		}
	}

	public class iOSModule : IContainerModule {
		
		public void Configure (Autofac.ContainerBuilder builder)
		{
			var localizable = DependencyService.Get<ILocalizable>();
			builder.RegisterInstance (localizable).As<ILocalizable> ();
			builder.RegisterType<Persister> ().As<IFilePersister> ();
		}
	}
}

