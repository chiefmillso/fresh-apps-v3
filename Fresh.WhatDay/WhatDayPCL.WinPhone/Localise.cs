using Xamarin.Forms;
using System.Globalization;
using Fresh.Core.Xamarin.Contracts;

[assembly:Dependency(typeof(WhatDayPCL.WinPhone.LocalizationProvider))]

namespace WhatDayPCL.WinPhone
{
    public class LocalizationProvider : ILocalizable
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }
    }
}