using System;

using Xamarin.Forms;
using Fresh.Core.Logging;
using Autofac;
using System.Reflection;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
	public class App : Application
	{
		IContainer _container;

		public App ()
		{
			if (Device.OS != TargetPlatform.WinPhone)
				AppResources.Culture = DependencyService.Get<ILocalise> ().GetCurrentCultureInfo ();

			var builder = new ContainerBuilder ();
			var assembly = typeof(App).GetTypeInfo ().Assembly;
			XamarinFormsModule.Configure (builder, assembly);

			var logger = DependencyService.Get<ILogger> ();
			var persister = DependencyService.Get<IPersister> ();
			builder.RegisterInstance (persister).AsImplementedInterfaces ();
			builder.RegisterInstance (logger).AsImplementedInterfaces ();
			builder.RegisterType<SettingsImpl> ().As<ISettings> ().SingleInstance ();

			_container = builder.Build ();
			var page = new SmartNavigationPage (_container, typeof(HomeViewModel));
			MainPage = page;
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

