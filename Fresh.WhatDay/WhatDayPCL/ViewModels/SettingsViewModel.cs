using System;

namespace WhatDayPCL
{
	public class SettingsViewModel
	{
		public SettingsViewModel ()
		{
			PageTitle = "Settings";
			StartDate = new DateTime (2014, 09, 08);
		}

		public string PageTitle { get; set; }

		public DateTime StartDate { get; set; }
	}

}

