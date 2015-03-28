using System;
using Fresh.Core.Xamarin;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Fresh.Core.Logging;
using WhatDayPCL.Localization;

namespace WhatDayPCL
{
	public class SettingsViewModel :  ViewModelBase
	{
		private readonly ILogger _logger;

		public SettingsViewModel (INavigation navigation, ISettings settings, ILogger logger)
		{
			this._logger = logger;
			this.PageAppeared += (sender, e) => {
				StartDate = settings.StartDate;
				IsLoaded = true;
			};
			this.PageDisappeared += (sender, e) => {
				settings.StartDate = StartDate;
			};

			NavigateToAbout = new Command (async (_) => {
				_logger.Info ("Navigating to About Page");
				await navigation.NavigateToAsync<AboutViewModel> ();
			});

			PageTitle = AppResources.Settings_PageTitle;
			StartDate = settings.StartDate;
		}

		public Command NavigateToAbout { get; set; }

		bool isLoaded;

		public bool IsLoaded {
			get {
				return isLoaded;
			}
			set {
				SetField (ref isLoaded, value);
			}
		}

		DateTime startDate;

		public DateTime StartDate {
			get {
				return startDate;
			}
			set {
				SetField (ref startDate, value);
			}
		}
	}

}

