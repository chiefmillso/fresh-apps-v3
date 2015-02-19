using System;
using Fresh.Core.Logging;

namespace WhatDayPCL
{
	public class DebugLogger : ILoggerImpl
	{
		#region ILogger implementation

		public void Log (LogLevel level, string format, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine (level.ToString().PadRight(8) + ": " + format, args);
		}

		public void Debug (string format, params object[] args)
		{
			Log (LogLevel.Debug, format, args);
		}

		public void Info (string format, params object[] args)
		{
			Log (LogLevel.Info, format, args);
		}

		public void Warn (string format, params object[] args)
		{
			Log (LogLevel.Warning, format, args);
		}

		public void Exception (string message, Exception ex, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine (ex.ToString());
		}

		public ILogger For<T> (T host = null) where T : class
		{
			return this;
		}

		public IDisposable Scope (string methodName, System.Collections.Generic.IDictionary<string, object> context = null)
		{
			return new Fresh.Core.Scopes.ActionDisposable (() => {
			});
		}

		public IDisposable Scope (string propertyName, object value)
		{
			return new Fresh.Core.Scopes.ActionDisposable (() => {
			});
		}

		#endregion
	}
}

