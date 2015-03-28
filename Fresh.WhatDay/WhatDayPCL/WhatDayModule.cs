using System;
using Fresh.Core.Contracts;
using Autofac;

namespace WhatDayPCL
{
	public class WhatDayModule : IContainerModule
	{
		public void Configure (Autofac.ContainerBuilder builder)
		{
			builder.RegisterType<SettingsImpl>().As<ISettings>().SingleInstance();
		}
	}
}

