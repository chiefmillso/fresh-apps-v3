using System;
using Fresh.Core.Xamarin;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WhatDayPCL
{
	public class SettingsViewModel : ViewModelBase
	{
		public SettingsViewModel (ISettings settings)
		{
			this.PageAppeared += (sender, e) => {
				StartDate = settings.StartDate;
				IsLoaded = true;
			};
			this.PageDisappeared += (sender, e) => {
				settings.StartDate = StartDate;
			};

			PageTitle = "Settings";
			StartDateLabel = "Start Date:";
			StartDate = settings.StartDate;
		}

		public string StartDateLabel { get; set; }

		bool isLoaded;

		public bool IsLoaded {
			get {
				return isLoaded;
			}
			set {
				SetField (ref isLoaded, value);
			}
		}

		public string PageTitle { get; set; }

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

