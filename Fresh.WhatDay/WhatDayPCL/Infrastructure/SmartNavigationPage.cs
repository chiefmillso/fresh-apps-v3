using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;

namespace WhatDayPCL
{
	public class SmartNavigationPage : NavigationPage
	{
		public SmartNavigationPage (IContainer container, Type pageType) : base (Init (container, pageType))
		{
		}

		private static Page Init (IContainer container, Type pageType)
		{
			var viewType = typeof(IViewFor<>).MakeGenericType (pageType);
			var view = container.Resolve (viewType) as IViewFor;
			var page = view as Page;
			var decorator = new NavigationDecorator (page.Navigation, (t) => Init(container, t));
			var model = container.Resolve (pageType, new NamedParameter ("navigation", decorator));
			view.BindingContext = model;
			return page;
		}
	}


}

