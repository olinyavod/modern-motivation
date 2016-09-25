using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Splat;
using Xamarin.Forms;

namespace Motivation.Mobile.Converters
{
	class BitmapToImageSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var bitmap = value as IBitmap;
			if (bitmap == null) return value;
			try
			{
				var stream = new MemoryStream();
				bitmap.Save(CompressedBitmapFormat.Png, 1, stream);
				stream.Seek(0, SeekOrigin.Begin);
					
				return ImageSource.FromStream(() => stream);

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
