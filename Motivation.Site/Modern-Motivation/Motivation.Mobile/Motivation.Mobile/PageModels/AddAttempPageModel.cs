using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.Settings;
using Acr.UserDialogs;
using FreshMvvm;
using Motivation.Mobile.Models;
using Motivation.Models;
using Plugin.Media.Abstractions;
using PropertyChanged;
using Simple.OData.Client;
using Splat;
using Xamarin.Forms;

namespace Motivation.Mobile.PageModels
{
	[ImplementPropertyChanged]
	public class AddAttempPageModel:FreshBasePageModel
	{
		private readonly IUserDialogs _userDialogs;
		private readonly IMedia _media;
		private readonly IFtpUploader _ftpUploader;
		private readonly ISettings _settings;

		public AddAttempPageModel(IUserDialogs userDialogs, 
			IMedia media,
			IFtpUploader ftpUploader,
			ISettings settings)
		{
			_userDialogs = userDialogs;
			_media = media;
			_ftpUploader = ftpUploader;
			_settings = settings;
			MustChooseFile = true;
		}

		UserStore _userStore = new UserStore();

		public override void Init(object initData)
		{
			base.Init(initData);
			_userStore = (UserStore) initData;
		}

		public ImageSource Cover { get; set; }

		public bool MustChooseFile { get; set; }

		public ICommand ChooseFileCommand => new Command(OnChooseFile);

		private void OnChooseFile(object obj)
		{
			_userDialogs.ActionSheet(new ActionSheetConfig()
				.SetTitle("Загрузка файла")
				.Add("Галерея", async () =>
				{
					var file = await _media.PickPhotoAsync();
					if (file != null)
					{
						await LoadFile(file);
					}
				})
				.Add("Камера", async () =>
				{
					var file = await _media.TakePhotoAsync(new StoreCameraMediaOptions
					{
						DefaultCamera = CameraDevice.Front
					});
					if (file != null)
					{
						await LoadFile(file);
					}
				})
				.SetCancel("Отмена"));
		}

		async Task LoadFile(MediaFile file)
		{
			try
			{
				using (var stream = file.GetStream())
				{
					file.Dispose();
					var buffer = new MemoryStream();
					await stream.CopyToAsync(buffer);
					buffer.Seek(0, SeekOrigin.Begin);
					Stream = buffer;
					Cover = ImageSource.FromStream(() =>
					{
						var ms = new MemoryStream();
						Stream.Seek(0, SeekOrigin.Begin);
						Stream.CopyTo(ms);
						ms.Seek(0, SeekOrigin.Begin);
						return ms;
					});
					MustChooseFile = false;
				}
			}
			catch (Exception ex)
			{
				_userDialogs.Alert(ex.Message, "Ошибка загруки файла");
			}
		}

		public Stream Stream { get; set; }

		public string FileName { get; set; }

		public string Comment { get; set; }

		public ICommand DoneCOmmand => new Command(OnDone);

		private async void OnDone(object obj)
		{
			if (Cover == null)
			{
				_userDialogs.Alert("Выбырите файл для загрузки");
				return;
			}
			try
			{
				using (_userDialogs.Loading("Загрузка..."))
				{
					using (var buffer = new MemoryStream())
					{
						Stream.Seek(0, SeekOrigin.Begin);
						await Stream.CopyToAsync(buffer);
						buffer.Seek(0, SeekOrigin.Begin);
						var fileId = $"{Guid.NewGuid()}.png";
						await _ftpUploader.UploadFile(fileId, buffer);
						var nettworkSettings = _settings.Get(NetworkSettingsStore.Key, new NetworkSettingsStore());
						var client = new ODataClient(nettworkSettings.ServerUrl);
						var item = await client.For<AchivmentAttemp>("AchivmentAttemps")
							.Set(new AchivmentAttemp
							{
								UserId = _userStore.UserId,
								FileName = FileName,
								Comment = Comment,
								AchivnedTypeId = AchimnetTypePostion + 1,
								FileUrl = new Uri(new Uri(nettworkSettings.ServerUrl), fileId).ToString(),
								FileExt = "Image",
								CreateDate = DateTime.Now
							})
							.InsertEntryAsync();
						await CoreMethods.PopPageModel();
					}

				}
			}
			catch(Exception ex)
			{
				_userDialogs.Alert(ex.Message);
			}
		}

		public int AchimnetTypePostion { get; set; }
	}
}
