using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Motivation.Mobile.Models;

namespace Motivation.Mobile.Droid.Providers
{
	class FtpUploader : IFtpUploader
	{
		private readonly string _ftpServer;
		private readonly string _user;
		private readonly string _password;

		public FtpUploader(NetworkSettingsStore networkSettings)
		{
			_ftpServer = networkSettings.FtpUrl;
			_user = networkSettings.FtpUser;
			_password = networkSettings.FtpPassword;
		}

		public async Task UploadFile(string fileName, Stream stream)
		{
			var ftp = (FtpWebRequest)WebRequest.Create(new Uri(new Uri(_ftpServer), fileName));
			
			ftp.Credentials = new NetworkCredential(_user, _password);

			ftp.KeepAlive = true;
			ftp.UseBinary = true;
			ftp.Method = WebRequestMethods.Ftp.UploadFile;

			

			byte[] buffer = new byte[stream.Length];
			stream.Read(buffer, 0, buffer.Length);

			stream.Close();

			Stream ftpstream = await ftp.GetRequestStreamAsync();
			await ftpstream.WriteAsync(buffer, 0, buffer.Length);
			ftpstream.Flush();
			ftpstream.Close();
			
		}
	}
}