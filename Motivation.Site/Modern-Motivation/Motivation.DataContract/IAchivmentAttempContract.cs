using System;
using Motivation.Models;

namespace Motivation.DataContract
{
	public interface IAchivmentAttempContract : IEntity
	{
		string FileName { get; set; }

		string FileExt { get; set; }

		string FileUrl { get; set; }

		bool IsCompleted { get; set; }

		bool IsAccepted { get; set; }

		string Comment { get; set; }

		DateTime CreateDate { get; set; }

		int UserId { get; set; }

		string AcceptUserName { get; set; }

		string AcceptUserGroupName { get; set; }

		string AchivmentTypeComment { get; set; }

		int? AchivmentTypeMaxCount { get; set; }

		int? AchivmentTypeExpCount { get; set; }

		int? AchivmentTypeCoinsCount { get; set; }

		string AchivmentTypeImageUrl { get; set; }
	}
}