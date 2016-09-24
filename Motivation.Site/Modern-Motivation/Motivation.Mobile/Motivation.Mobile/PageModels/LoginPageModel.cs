using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.Settings;
using Acr.UserDialogs;
using FreshMvvm;
using Microsoft.OData.Edm;
using Motivation.Mobile.Models;
using PropertyChanged;
using Simple.OData.Client;
using Xamarin.Forms;

namespace Motivation.Mobile.PageModels
{
	[ImplementPropertyChanged]
	public class LoginPageModel : FreshBasePageModel
	{
		private readonly IUserDialogs _userDialogs;
		private readonly ISettings _settings;

		public LoginPageModel(IUserDialogs userDialogs, ISettings settings)
		{
			_userDialogs = userDialogs;
			_settings = settings;
		}

		public string Login { get; set; }

		public string Password { get; set; }

		public ICommand SignInCommand => new Command(OnSignIn);

		private async void OnSignIn()
		{
			try
			{
				using (_userDialogs.Loading("Подключение..."))
				{
					var netqorkSettings = _settings.Get(NetworkSettingsStore.Key, new NetworkSettingsStore());
					var client = new ODataClient(netqorkSettings.ServerUrl);
					var user = await client.For<UserDto>()
						.Filter(i => i.Login == Login && i.Password == Password)
						.FindEntryAsync();

					if (user != null)
					{

						_settings.Set(UserStore.Key, new UserStore
						{
							UserId = user.Id,
							HasUser = true
						});
						_userDialogs.Alert("Подключился");
					}
					else
						_userDialogs.Alert("Некорректный логин или пароль");
				}
			}
			catch (Exception ex)
			{
				_userDialogs.Alert(ex.Message, "Ошибка подключения...");
			}
		}

		public ICommand NettworkSettingsCommand => new Command(OnNettworkSettings);

		private async void OnNettworkSettings()
		{
			var store = _settings.Get<NetworkSettingsStore>(NetworkSettingsStore.Key, new NetworkSettingsStore());
			var result = await _userDialogs.PromptAsync(new PromptConfig()
				.SetTitle("Настройки")
				.SetMessage("Укажите адрес сервера:")
				.SetText(store.ServerUrl));
			if (result.Ok)
			{
				_settings.Set(NetworkSettingsStore.Key, new NetworkSettingsStore
				{
					ServerUrl = result.Value
				});
			}
		}
	}
}
