using System;
using Fresh.Core.Configuration;
using Fresh.Core.Xamarin.Contracts;

namespace WhatDayPCL
{
	public class AboutViewModel : ViewModelBase
	{
		public AboutViewModel (ILocalizable localizable)
		{
			PageTitle = "What Day - 1.0.0";
			Copyright = "Copyright 2015 - Freshly Squeezed Code";
			VersionText = "1.0.0";
			Culture = localizable.GetCurrentCultureInfo ().DisplayName;
		}

		public string VersionText { get; set; }

		public string Copyright { get; set; }

		public string PageTitle { get; set; }

		public string Culture { get; set; }
	}
}

