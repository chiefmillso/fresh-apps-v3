using System;
using System.Threading.Tasks;

namespace WhatDayPCL
{
	public interface IPersister
	{
		Task Save (string json);

		Task<string> Load ();
	}

	public interface ISettings
	{
		DateTime StartDate { get; set; }

		event EventHandler Loaded;
	}

	public class SettingsImpl : ISettings
	{
		private IPersister _persister;

		public event EventHandler Loaded = (s,e) => {};

		public SettingsImpl (IPersister persister)
		{
			_persister = persister;

			startDate = DateTime.Now;
			var scheduler = TaskScheduler.FromCurrentSynchronizationContext ();
			Load ().ContinueWith ((t) => {
				Loaded (this, new EventArgs ());
			}, scheduler);
		}

		private async Task Load ()
		{
			long ticks = 0;
			var result = await _persister.Load ();
			if (long.TryParse (result, out ticks))
				startDate = new DateTime (ticks);
		}

		DateTime startDate;

		public DateTime StartDate {
			get {
				return startDate;
			}
			set {
				if (value != startDate) {
					_persister.Save (value.Ticks.ToString ());
				}
				startDate = value;
			}
		}

	}
}

