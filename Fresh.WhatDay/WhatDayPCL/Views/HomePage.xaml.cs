﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhatDayPCL
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

			BindingContext = new HomeViewModel (Navigation);
		}
	}
}

