using System;

using Xamarin.Forms;
using Fresh.Core.Logging;
using Autofac;
using System.Reflection;

namespace WhatDayPCL
{
	public class App : Application
	{
		IContainer _container;

		public App ()
		{
			var builder = new ContainerBuilder ();
			var assembly = typeof(App).GetTypeInfo ().Assembly;
			builder.RegisterAssemblyTypes (assembly)
				.AsClosedTypesOf (typeof(IViewFor<>))
				.SingleInstance ();
			builder.RegisterAssemblyTypes (assembly)
				.Where (x => x.Name.EndsWith ("ViewModel"))
				.AsSelf ();

			builder.RegisterType<MessagingServiceAdapter> ()
				.As<IMessagingService> ()
				.SingleInstance ();

			var logger = DependencyService.Get<ILogger> ();
			builder.RegisterInstance (logger).AsImplementedInterfaces ();

			_container = builder.Build ();
			var page = new SmartNavigationPage(_container, typeof(HomeViewModel));
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

