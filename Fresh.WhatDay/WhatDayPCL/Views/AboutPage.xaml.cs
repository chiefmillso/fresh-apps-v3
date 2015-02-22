using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
	public partial class AboutPage : ContentPage, IViewFor<AboutViewModel>
	{
		public AboutPage ()
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

