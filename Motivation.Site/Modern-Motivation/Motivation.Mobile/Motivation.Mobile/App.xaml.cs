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
using Plugin.Media;
using Splat;
using Xamarin.Forms;

namespace Motivation.Mobile
{
	public partial class App : Application
	{
		public const string MainNavigationService = "DefaultNavigationServiceName";

		public App()
		{
			InitializeComponent();
			FreshIOC.Container.Register(UserDialogs.Instance);
			FreshIOC.Container.Register(Settings.Local);
			FreshIOC.Container.Register(CrossMedia.Current);
			FreshIOC.Container.Register(BitmapLoader.Current);
			FreshIOC.Container.Register(new NetworkSettingsStore());
			CrossMedia.Current.Initialize();
			var userStore = FreshIOC.Container.Resolve<ISettings>().Get(UserStore.Key, new UserStore());

			if (!userStore.HasUser)
				ShowLoginPage();
			else 
				ShowMainPage();

		}

		public void ShowLoginPage()
		{
			MainPage = new AppNavigationBar(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
		}

		public void ShowMainPage()
		{
			var settings = FreshIOC.Container.Resolve<ISettings>();
			var userStore = settings.Get(UserStore.Key, new UserStore());
			var masterDetailNav = new FreshMasterDetailNavigationContainer(MainNavigationService)
			{
				MasterBehavior = MasterBehavior.Popover
			};
			masterDetailNav.Init("Меню", "MenuIcon.png");
			masterDetailNav.AddPage<AchivmentAttempPageModel>("Мои файлы", userStore);
			masterDetailNav.AddPage<EventsListPageModel>("События", userStore);
			MainPage = masterDetailNav;
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
