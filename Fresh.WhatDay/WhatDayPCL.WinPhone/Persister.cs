using System.Threading.Tasks;
using Fresh.Core.Xamarin;
using WhatDayPCL.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof (Persister))]

namespace WhatDayPCL.WinPhone
{
    public class Persister : IPersister
    {
        private readonly IFilePersister _filePersister;

        static Persister()
        {
            Filename = "WhatDayPCL";
        }

        public Persister()
        {
            _filePersister = DependencyService.Get<IFilePersister>();
        }

        public static string Filename { get; set; }

        public async Task Save(string json)
        {
            await _filePersister.SaveAsync(Filename, json);
        }

        public async Task<string> Load()
        {
            string result;
            try
            {
                result = await _filePersister.LoadAsync(Filename);
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}