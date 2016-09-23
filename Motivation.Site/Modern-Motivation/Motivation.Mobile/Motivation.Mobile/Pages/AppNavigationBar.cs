using Xamarin.Forms;

namespace Motivation.Mobile.Pages
{
	public class AppNavigationBar : NavigationPage
	{
		public AppNavigationBar(Page page)
			:base(page)
		{
			BarBackgroundColor = ((Color) Application.Current.Resources["NavigationBarColor"]);
			BarTextColor = Color.White;
		}
	}
}
