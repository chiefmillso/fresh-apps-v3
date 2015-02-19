using System;
using Xamarin.Forms;
using Fresh.Core.Scopes;

namespace WhatDayPCL
{

	public class MessagingServiceAdapter : IMessagingService
	{
		public void Unsubscribe<TSender> (object subscriber, string message) where TSender : class
		{
			MessagingCenter.Unsubscribe<TSender> (subscriber, message);
		}

		public void Unsubscribe<TSender, TArgs> (object subscriber, string message) where TSender : class
		{
			MessagingCenter.Unsubscribe<TSender, TArgs> (subscriber, message);
		}

		public void Send<TSender> (TSender sender, string message) where TSender : class
		{
			MessagingCenter.Send<TSender> (sender, message);
		}

		public void Send<TSender, TArgs> (TSender sender, string message, TArgs args) where TSender : class
		{
			MessagingCenter.Send<TSender, TArgs> (sender, message, args);
		}

		public IDisposable Subscribe<TSender> (object subscriber, string message, Action<TSender> callback, TSender source = null)  where TSender : class
		{
			Action unsubscribe = () => {
				MessagingCenter.Unsubscribe<TSender> (subscriber, message);
			};
			MessagingCenter.Subscribe<TSender> (subscriber, message, callback, source);
			return new ActionDisposable (unsubscribe);
		}

		public IDisposable Subscribe<TSender, TArgs> (object subscriber, string message, Action<TSender, TArgs> callback, TSender source = null)  where TSender : class
		{
			Action unsubscribe = () => {
				MessagingCenter.Unsubscribe<TSender, TArgs> (subscriber, message);
			};
			MessagingCenter.Subscribe<TSender, TArgs> (subscriber, message, callback, source);
			return new ActionDisposable (unsubscribe);
		}
	}
}
