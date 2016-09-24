using Acr.Settings;
using FreshMvvm;
using Motivation.Mobile.Models;

namespace Motivation.Mobile.PageModels
{
	public class MainPageModel : FreshBasePageModel
	{
		private readonly ISettings _settings;

		public MainPageModel(ISettings settings)
		{
			_settings = settings;
		}

		public override async void Init(object initData)
		{
			base.Init(initData);
			var userStore = _settings.Get(UserStore.Key, new UserStore());
		}
	}
}