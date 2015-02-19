using System;
using Xamarin.Forms;
using Fresh.Core.Scopes;

namespace WhatDayPCL
{
	public interface IViewFor<T> : IViewFor
	{
	}

	public interface IViewFor
	{
		object BindingContext { set; }
	}


}

