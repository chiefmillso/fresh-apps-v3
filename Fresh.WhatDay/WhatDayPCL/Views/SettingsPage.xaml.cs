using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhatDayPCL
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();

			BindingContext = new SettingsViewModel ();
		}
	}
}

