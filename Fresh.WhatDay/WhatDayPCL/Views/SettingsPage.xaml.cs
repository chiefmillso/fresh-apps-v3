using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
	public partial class SettingsPage : ContentPage, IViewFor<SettingsViewModel>
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			this.OnPageAppearing ();
		}

		protected override void OnDisappearing ()
		{
			this.OnPageDisappearing ();
		}
	}
}

