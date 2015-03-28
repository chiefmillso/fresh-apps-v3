using System;
using System.Diagnostics;
using Xamarin.Forms;
using Fresh.Core.Logging;
using Autofac;
using System.Reflection;
using Fresh.Core.Xamarin;
using Fresh.Core.Configuration;
using Fresh.Core.Xamarin.Contracts;

namespace WhatDayPCL
{
	public class App : ApplicationBase<App,HomeViewModel>
	{
		public App () : base(ContainerInit)
		{
		}

		private static void ContainerInit(IContainer container)
		{
            Localization.AppResources.Culture = container.Resolve<ILocalizable> ().GetCurrentCultureInfo ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

