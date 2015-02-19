using System;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;

namespace WhatDayPCL
{

	public class NavigationDecorator : INavigation
	{
		INavigation inner;
		Func<Type, Page> factory;

		public Page Create<T>() where T : class {
			var page = factory (typeof(T)) as Page;
			return page;
		}

		public NavigationDecorator (INavigation inner, Func<Type, Page> factory)
		{
			this.inner = inner;
			this.factory = factory;
		}

		#region INavigation implementation

		public void RemovePage (Page page)
		{
			inner.RemovePage (page);
		}

		public void InsertPageBefore (Page page, Page before)
		{
			inner.InsertPageBefore (page, before);
		}

		public Task PushAsync (Page page)
		{
			return inner.PushAsync (page);
		}

		public Task<Page> PopAsync ()
		{
			return inner.PopAsync ();
		}

		public Task PopToRootAsync ()
		{
			return inner.PopToRootAsync ();
		}

		public Task PushModalAsync (Page page)
		{
			return inner.PushModalAsync (page);
		}

		public Task<Page> PopModalAsync ()
		{
			return inner.PopModalAsync ();
		}

		public Task PushAsync (Page page, bool animated)
		{
			return inner.PushAsync (page, animated);
		}

		public Task<Page> PopAsync (bool animated)
		{
			return inner.PopAsync (animated);
		}

		public Task PopToRootAsync (bool animated)
		{
			return inner.PopToRootAsync (animated);
		}

		public Task PushModalAsync (Page page, bool animated)
		{
			return inner.PushModalAsync (page, animated);
		}

		public Task<Page> PopModalAsync (bool animated)
		{
			return inner.PopModalAsync (animated);
		}

		public System.Collections.Generic.IReadOnlyList<Page> NavigationStack {
			get {
				return inner.NavigationStack;
			}
		}

		public System.Collections.Generic.IReadOnlyList<Page> ModalStack {
			get {
				return inner.ModalStack;
			}
		}

		#endregion
	}
}
