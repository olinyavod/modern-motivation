using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace Motivation.Mobile.Pages
{
	public partial class MainPage : IFreshNavigationService
	{
		public MainPage()
		{
			InitializeComponent();
			NavigationServiceName = "MainNavigation";
			Master = new MenuPage();
			Detail = new MyContentListPage();
		}

		public async Task PopToRoot(bool animate = true)
		{
			await Navigation.PopToRootAsync(animate);
		}

		public async Task PushPage(Page page, FreshBasePageModel model, bool modal = false, bool animate = true)
		{
			if (modal)
				await Navigation.PushModalAsync(new AppNavigationBar(page), animate);
			else
				await Navigation.PushAsync(new AppNavigationBar(page), animate);
		}

		public async Task PopPage(bool modal = false, bool animate = true)
		{
			if (modal)
				await Navigation.PopModalAsync(animate);
			else await Navigation.PopAsync(animate);
		}

		public Task<FreshBasePageModel> SwitchSelectedRootPageModel<T>() where T : FreshBasePageModel
		{
			throw new System.NotImplementedException();
		}

		public void NotifyChildrenPageWasPopped()
		{
			throw new System.NotImplementedException();
		}

		public string NavigationServiceName { get; }
	}
}
