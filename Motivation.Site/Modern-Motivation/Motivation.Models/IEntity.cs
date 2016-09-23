using System;

namespace Motivation.Models
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

	public interface IEntity : IEntity<int>
	{
		
	}
}