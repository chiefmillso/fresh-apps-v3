using System;
using System.Threading.Tasks;
using Fresh.Core.Xamarin;

namespace WhatDayPCL
{
    public class SettingsImpl : ISettings
	{
		private IFilePersister _persister;

		public event EventHandler Loaded = (s,e) => {};

        public SettingsImpl(IFilePersister persister)
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
		    try
		    {
		        var result = await _persister.LoadAsync("WhatDayPCL");
		        if (long.TryParse(result, out ticks))
		            startDate = new DateTime(ticks);
		    }
		    catch
		    {
		    }
		}

		DateTime startDate;

		public DateTime StartDate {
			get {
				return startDate;
			}
			set {
				if (value != startDate) {
					_persister.SaveAsync("WhatDayPCL", value.Ticks.ToString ());
				}
				startDate = value;
			}
		}

	}
}

