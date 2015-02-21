using System;
using WhatDayPCL;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency (typeof(WhatDayPCL.iOS.Persister))]

namespace WhatDayPCL.iOS
{
	public class Persister : IPersister
	{
		public Task Save (string json)
		{
			SaveText ("WhatDayPCL", json);
			return Task.Delay (0);
		}

		public Task<string> Load ()
		{
			string result;
			try {
				result = LoadText ("WhatDayPCL");
			} catch {
				result = null;
			}
			return Task.FromResult (result);
		}


		public void SaveText (string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			System.IO.File.WriteAllText (filePath, text);
		}

		public string LoadText (string filename)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}
	}
}

