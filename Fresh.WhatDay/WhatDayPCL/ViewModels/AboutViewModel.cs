using System;

namespace WhatDayPCL
{
	public class AboutViewModel : ViewModelBase
	{
		public AboutViewModel ()
		{
			PageTitle = "What Day - 1.0.0";
			Copyright = "Copyright 2015 - Freshly Squeezed Code";
			VersionText = "1.0.0";
		}

		public string VersionText { get; set; }

		public string Copyright { get; set; }

		public string PageTitle { get; set; }
	}
}

