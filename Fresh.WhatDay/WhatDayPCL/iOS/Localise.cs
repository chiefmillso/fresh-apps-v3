using Foundation;
[assembly:Xamarin.Forms.Dependency(typeof(WhatDayPCL.iOS.Localise))]

namespace WhatDayPCL.iOS
{
	public class Localise : ILocalise
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var netLanguage = "en";
			if (NSLocale.PreferredLanguages.Length > 0) {
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-"); // turns pt_BR into pt-BR
			}
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}