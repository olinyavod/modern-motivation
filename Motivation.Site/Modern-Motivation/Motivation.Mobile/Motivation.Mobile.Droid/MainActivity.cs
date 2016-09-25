using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FreshMvvm;
using Motivation.Mobile.Droid.Providers;
using Motivation.Mobile.Models;
using Splat;

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]

namespace Motivation.Mobile.Droid
{
	[Activity(Label = "Motivation.Mobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);
			UserDialogs.Init(this);
			FreshIOC.Container.Register((IFtpUploader)new FtpUploader(new NetworkSettingsStore()));
			global::Xamarin.Forms.Forms.Init(this, bundle);
			
			LoadApplication(new App());
		}
	}
}

