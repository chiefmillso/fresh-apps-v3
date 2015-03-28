using System;

using Xamarin.Forms;
using Fresh.Core.Logging;
using Autofac;
using System.Reflection;
using Fresh.Core.Xamarin;
using Fresh.Core.Configuration;
using Fresh.Core.Xamarin.Contracts;

namespace WhatDayPCL
{
	public class App : Application
	{
	    private readonly IContainer _container;

		public App ()
		{
		    var logger = DependencyService.Get<ILogger>();
		    try
		    {
		        var localizable = DependencyService.Get<ILocalizable>();
		        if (Device.OS != TargetPlatform.WinPhone)
		            Localization.AppResources.Culture = localizable.GetCurrentCultureInfo();

		        Settings.Instance.Initialize(this);

		        var builder = new ContainerBuilder();
		        var assembly = typeof (App).GetTypeInfo().Assembly;
		        XamarinFormsModule.Configure(builder, assembly);

				builder.RegisterInstance(logger).AsImplementedInterfaces();
		        builder.RegisterType<SettingsImpl>().As<ISettings>().SingleInstance();

		        _container = builder.Build();
		        var page = new SmartNavigationPage(_container, typeof (HomeViewModel));
		        MainPage = page;

		    }
		    catch (Exception ex)
		    {
	            logger.Exception(ex.Message, ex);
		        throw;
		    }
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

