﻿using System;
using Android.App;
using Android.Content;
using Android.Support.CustomTabs;
using Fly360;
using Fly360.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidNativeBrowserService))]
namespace Fly360.Droid
{
    public class AndroidNativeBrowserService : INativeBrowserService
    {
        CustomTabsActivityManager customTabs;

        public void LaunchNativeEmbeddedBrowser(string url)
        {
            // TODO: We need the current actiivty. Forms.Context is deprecated, but I had issues
            // trying to use Android.App.Appllication.Context when casting to Activity, sooo...?
            var activity = Forms.Context as Activity;

            if (activity == null) return;

            var mgr = new CustomTabsActivityManager(activity);
            mgr.CustomTabsServiceConnected += delegate {
                mgr.LaunchUrl(url);
            };

            mgr.BindService();
        }
    }
}