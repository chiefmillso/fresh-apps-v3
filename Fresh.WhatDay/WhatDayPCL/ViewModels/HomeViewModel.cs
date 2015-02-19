using System;
using Xamarin.Forms;
using Fresh.Core.Logging;

namespace WhatDayPCL
{
	public class HomeViewModel
	{
		ILogger _logger;

		public HomeViewModel (INavigation navigation, ILogger logger)
		{
			_logger = logger.For (this);

			PageTitle = "What Day Is It?";
			LabelText = "Day 162";
			DayText = "Thursday, 19 February 2015";
			SettingsButtonText = "Settings";

			NavigateToSettings = new Command (async (_) => {
				_logger.Info("Navigating to Settings");
				await navigation.NavigateToAsync<SettingsViewModel>();
			});
		}

		public Command NavigateToSettings { get; set; }

		public string SettingsButtonText { get; set; }

		public string PageTitle { get; set; }

		public string LabelText { get; set; }

		public string DayText { get; set; }
	}
}
