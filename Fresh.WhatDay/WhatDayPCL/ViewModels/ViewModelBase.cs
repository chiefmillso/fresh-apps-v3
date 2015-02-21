using System;
using Fresh.Core.Xamarin;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace WhatDayPCL
{
	public abstract class ViewModelBase : IPageLifecycle, INotifyPropertyChanged
	{
		public event EventHandler PageAppeared = (s,e) => {};
		public event EventHandler PageDisappeared = (s,e) => {};

		#region IPageLifecycle implementation

		public void OnAppearing ()
		{
			PageAppeared (this, new EventArgs());
		}

		public void OnDisappearing ()
		{
			PageDisappeared (this, new EventArgs ());
		}

		public bool OnBackButtonPressed ()
		{
			return true;
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}

		protected bool SetField<T> (ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (propertyName == null)
				return false;
			if (EqualityComparer<T>.Default.Equals (field, value))
				return false;
			field = value;
			OnPropertyChanged (propertyName);
			return true;
		}

		#endregion
	}
}

