using System.IO;
using System.Threading.Tasks;

namespace Motivation.Mobile
{
	public interface IFtpUploader
	{
		Task UploadFile(string fileName, Stream stream);
	}
}