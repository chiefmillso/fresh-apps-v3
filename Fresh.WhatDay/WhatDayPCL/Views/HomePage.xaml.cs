using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fresh.Core.Logging;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
	public partial class HomePage : ContentPage, IViewFor<HomeViewModel>
	{
		public HomePage ()
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

