using System.Collections.Generic;
using Fresh.Core.Contracts;
using Fresh.Core.Logging;
using Fresh.Core.WinPhone;
using WhatDayPCL.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof (LocalizationProvider))]
[assembly: Dependency(typeof (PlatformLogger))]
[assembly: Dependency(typeof (ModulesProvider))]

namespace WhatDayPCL.WinPhone
{
    public class PlatformLogger : LoggingFacade
    {
        public PlatformLogger() : base(new DebugLogger(), new ExceptionlessLogger())
        {
        }
    }

    public class ModulesProvider : IModulesProvider
    {
        public IContainerModule[] Provide()
        {
            var modules = new List<IContainerModule> {new WinPhoneModule()};
            return modules.ToArray();
        }
    }
}