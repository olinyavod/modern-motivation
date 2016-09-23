using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motivation.Models
{
    public class User : EntityBase
    {
	    public string Login { get; set; }

	    public string Title { get; set; }

	    public string Password { get; set; }

	    public UserGroup Group { get; set; }

	    public bool IsGeneral { get; set; }

	    public DateTime? Bithday { get; set; }
    }
}
