using Fresh.Core.Logging;
using Fresh.Core.Contracts;
using System.Collections.Generic;
using Fresh.Core.Xamarin;
using Autofac;
using Fresh.Core.Xamarin.Contracts;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.Droid.PlatformLogger))]
[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.Droid.ModulesProvider))]
[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.Droid.Localise))]

namespace WhatDayPCL.Droid
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
			list.Add (new DroidModule ());
			return list.ToArray ();
		}
	}

	public class DroidModule : IContainerModule {
		
		public void Configure (Autofac.ContainerBuilder builder)
		{
			var localizable = DependencyService.Get<ILocalizable>();
			builder.RegisterInstance (localizable).As<ILocalizable> ();
			builder.RegisterType<Persister> ().As<IFilePersister> ();
		}
	}

	public class Localise : ILocalizable
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace ("_", "-"); // turns pt_BR into pt-BR
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

