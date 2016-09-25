using System;
using System.Windows.Input;
using Motivation.DataContract;
using PropertyChanged;

namespace Motivation.Mobile.Models
{
	[ImplementPropertyChanged]
	public class AchivmentAttempDto : IAchivmentAttempContract
	{
		public int Id { get; set; }
		public string FileName { get; set; }
		public string FileExt { get; set; }
		public string FileUrl { get; set; }
		public bool IsCompleted { get; set; }
		public bool IsAccepted { get; set; }
		public string Comment { get; set; }
		public DateTime CreateDate { get; set; }
		public int UserId { get; set; }
		public string AcceptUserName { get; set; }
		public string AcceptUserGroupName { get; set; }
		public string AchivmentTypeComment { get; set; }
		public int AchivmentTypeMaxCount { get; set; }
		public int AchivmentTypeExpCount { get; set; }
		public int AchivmentTypeCoinsCount { get; set; }
		public string AchivmentTypeImageUrl { get; set; }
	}
}