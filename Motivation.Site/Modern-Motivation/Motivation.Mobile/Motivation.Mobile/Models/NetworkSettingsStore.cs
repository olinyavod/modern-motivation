namespace Motivation.Mobile.Models
{
	public class NetworkSettingsStore
	{
		public NetworkSettingsStore()
		{
			FtpUrl = "ftp://service.easy-prog.com/";
			FtpUser = "service";
			FtpPassword = "qwerty";
			ServerUrl = "http://service.easy-prog.com";
		}

		public string ServerUrl { get; set; }
		public string FtpUrl { get; set; }
		public string FtpUser { get; set; }
		public string FtpPassword { get; set; }

		public const string Key = "NetworkSettings";
	}
}