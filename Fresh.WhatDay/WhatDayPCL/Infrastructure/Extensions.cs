using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;

namespace WhatDayPCL
{

	public static class Extensions
	{
	
		private static NavigationDecorator Advanced (this INavigation navigation)
		{
			var decorated = navigation as NavigationDecorator;
			if (decorated == null)
				throw new Exception ();
			return decorated;
		}

		public static Task NavigateToAsync<T> (this INavigation navigation) where T : class
		{
			return NavigateToAsync<T> (navigation, true);
		}

		public static Task NavigateToModalAsync<T> (this INavigation navigation) where T : class
		{
			return NavigateToModalAsync<T> (navigation, true);
		}

		public static Task NavigateToAsync<T> (this INavigation navigation, bool animated) where T : class
		{
			var page = navigation.Advanced ().Create<T> () as Page;
			return navigation.PushAsync (page, animated);
		}

		public static Task NavigateToModalAsync<T> (this INavigation navigation, bool animated) where T : class
		{
			var page = navigation.Advanced ().Create<T> () as Page;
			return navigation.PushModalAsync (page, animated);
		}
	}

}
