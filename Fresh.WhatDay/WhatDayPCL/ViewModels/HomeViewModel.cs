using System;
using Xamarin.Forms;

namespace WhatDayPCL
{
	public class HomeViewModel
	{
		public HomeViewModel (INavigation navigation)
		{
			PageTitle = "What Day Is It?";
			LabelText = "Day 162";
			DayText = "Thursday, 19 February 2015";
			SettingsButtonText = "Settings";

			NavigateToSettings = new Command (async (_) => {
				await navigation.PushAsync (new SettingsPage ());
			});
		}

		public Command NavigateToSettings { get; set; }

		public string SettingsButtonText { get; set; }

		public string PageTitle { get; set; }

		public string LabelText { get; set; }

		public string DayText { get; set; }
	}
}
