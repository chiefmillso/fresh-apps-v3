using System.Collections.Generic;
using System.Linq;
using Autofac;
using Fresh.Core.Contracts;
using Fresh.Core.Logging;
using Fresh.Core.WinPhone;
using WhatDayPCL.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof (ModulesProvider))]

namespace WhatDayPCL.WinPhone
{
    public class ModulesProvider : IModulesProvider
    {
        public IContainerModule[] Provide()
        {
            var modules = new List<IContainerModule>
            {
                new WhatDayModule(),
                new WinPhoneModule(),
                new LoggingWinPhoneModule()
            };
            return modules.ToArray();
        }
    }

    public class PlatformLogger : LoggingFacade
    {
        public PlatformLogger(ILoggerImpl[] loggers) : base(loggers.Cast<ILogger>().ToArray())
        {
        }
    }

    public class LoggingWinPhoneModule : IContainerModule
    {
        public void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<DebugLogger>()
                .As<ILoggerImpl>();

            builder.RegisterType<PlatformLogger>()
                .As<ILogger>()
                .SingleInstance();
        }
    }
}