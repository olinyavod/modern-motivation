using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.Settings;
using Acr.UserDialogs;
using FreshMvvm;
using Motivation.Mobile.Models;
using Motivation.Mobile.PageModels;
using Motivation.Mobile.Pages;
using Xamarin.Forms;

namespace Motivation.Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			FreshIOC.Container.Register(UserDialogs.Instance);
			FreshIOC.Container.Register(Settings.Roaming);

			var userStore = FreshIOC.Container.Resolve<ISettings>().Get(UserStore.Key, new UserStore());

			MainPage = userStore.HasUser
				? new AppNavigationBar(FreshPageModelResolver.ResolvePageModel<MainPageModel>())
				: new AppNavigationBar(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
