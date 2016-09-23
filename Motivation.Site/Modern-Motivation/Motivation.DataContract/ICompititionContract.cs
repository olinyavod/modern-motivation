using System;
using Motivation.Models;

namespace Motivation.DataContract
{
	public interface ICompititionContract : IEntity
	{
		DateTime StartDate { get; set; }

		DateTime EndDate { get; set; }

		string Comment { get; set; }

		string ImageUrl { get; set; }
	}
}