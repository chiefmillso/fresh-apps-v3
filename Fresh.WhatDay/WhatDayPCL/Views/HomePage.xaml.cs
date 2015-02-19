using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fresh.Core.Logging;

namespace WhatDayPCL
{
	public partial class HomePage : ContentPage, IViewFor<HomeViewModel>
	{
		public HomePage ()
		{
			InitializeComponent ();
		}
	}
}

