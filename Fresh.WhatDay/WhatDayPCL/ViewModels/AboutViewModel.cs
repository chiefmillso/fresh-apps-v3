using Fresh.Core.Xamarin;
using Fresh.Core.Xamarin.Contracts;

namespace WhatDayPCL
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(ILocalizable localizable)
        {
			PageTitle = Localization.AppResources.About_PageTitle;
            Copyright = "Copyright 2015 - Freshly Squeezed Code";
            VersionText = "1.0.0";
            Culture = localizable.GetCurrentCultureInfo().DisplayName;
        }

        public string VersionText { get; set; }

        public string Copyright { get; set; }

        public string Culture { get; set; }
    }
}