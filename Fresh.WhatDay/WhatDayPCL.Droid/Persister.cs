using System;
using WhatDayPCL;
using System.IO;
using System.Threading.Tasks;
using Fresh.Core.Xamarin;

namespace WhatDayPCL.Droid
{
	public class Persister : IFilePersister
	{
		#region IFilePersister implementation

		public Task SaveAsync (string filename, string json)
		{
			SaveText (filename, json);
			return Task.Delay (0);
		}

		public Task<string> LoadAsync (string filename)
		{string result;
			try {
				result = LoadText (filename);
			} catch {
				result = null;
			}
			return Task.FromResult (result);
		}

		#endregion

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

