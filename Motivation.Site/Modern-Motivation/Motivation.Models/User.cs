using System;

namespace Motivation.Models
{
    public class User : EntityBase
    {
	    public string Login { get; set; }

	    public string Name { get; set; }

	    public string Password { get; set; }

	    public UserGroup UserGroup { get; set; }

	    public int UserGroupId { get; set; }

	    public bool IsGeneral { get; set; }

	    public DateTime? Birthday { get; set; }

	    public int Exp { get; set; }

	    public int CoinsCount { get; set; }

	    public string AvatarUrl { get; set; }
    }
}
