using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Acr.Settings;
using Acr.UserDialogs;
using FreshMvvm;
using Motivation.Mobile.Models;
using Motivation.Models;
using PropertyChanged;
using Simple.OData.Client;
using Xamarin.Forms;

namespace Motivation.Mobile.PageModels
{
	[ImplementPropertyChanged]
	public class AchivmentAttempPageModel : FreshBasePageModel
	{
		private readonly IUserDialogs _userDialogs;
		private readonly ISettings _settings;

		UserStore _userStore;

		public AchivmentAttempPageModel(IUserDialogs userDialogs, ISettings settings)
		{
			_userDialogs = userDialogs;
			_settings = settings;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			_userStore = (UserStore) initData;
			OnRefresh();

		}

		public ICommand RefreshCommand => new Command(OnRefresh);

		private async void OnRefresh()
		{
			try
			{
				using (_userDialogs.Loading("Загрузка..."))
				{
					var ns = _settings.Get(NetworkSettingsStore.Key, new NetworkSettingsStore());
					var client = new ODataClient(ns.ServerUrl);
					var result = await client
						.For<AchivmentAttempDto>("AchivmentAttempItems")
						.FindEntriesAsync();
					ItemsSource = new ObservableCollection<AchivmentAttempDto>(result.Where(i => i.UserId == _userStore.UserId));
				}
			}
			catch
			{
				
			}
		}

		public ObservableCollection<AchivmentAttempDto> ItemsSource { get; set; }

		public ICommand AddAttempCommand => new Command(OnAddAttemp);

		private void OnAddAttemp(object obj)
		{
			var page = FreshPageModelResolver.ResolvePageModel<AddAttempPageModel>(_userStore);
			FreshIOC.Container.Resolve<IFreshNavigationService>(App.MainNavigationService)
				.PushPage(page, ((FreshBasePageModel) page.BindingContext));
		}
	}

	
	
}
