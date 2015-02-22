using System;
using Xamarin.Forms;
using Fresh.Core.Logging;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
	public class HomeViewModel : ViewModelBase
	{
		ILogger _logger;
		ISettings _settings;

		public HomeViewModel (INavigation navigation, ILogger logger, ISettings settings)
		{
			_logger = logger.For (this);
			_settings = settings;

			_settings.Loaded += (sender, e) => {
				Calculate ();
			};

			PageAppeared += (sender, e) => {
				Calculate ();
			};

			PageTitle = AppResources.HomePageTitle;
			LabelText = "";
			DayText = "";
			SettingsButtonText = AppResources.SettingsButtonLabel;

			NavigateToSettings = new Command (async (_) => {
				_logger.Info ("Navigating to Settings");
				await navigation.NavigateToAsync<SettingsViewModel> ();
			});
		}

		private void Calculate ()
		{
			_logger.Info ("Calculating date based on {0:d}", _settings.StartDate);

			var duration = DateTime.Now.Subtract (_settings.StartDate);
			LabelText = string.Format (AppResources.DayCountFormat, (int)Math.Ceiling (duration.TotalDays));
			DayText = DateTime.Now.ToString ("D");
		}

		public Command NavigateToSettings { get; set; }

		public string SettingsButtonText { get; set; }

		public string PageTitle { get; set; }

		string labelText;

		public string LabelText {
			get {
				return labelText;
			}
			set {
				SetField (ref labelText, value);
			}
		}

		string dayText;

		public string DayText {
			get {
				return dayText;
			}
			set {
				SetField (ref dayText, value);
			}
		}
	}
}
