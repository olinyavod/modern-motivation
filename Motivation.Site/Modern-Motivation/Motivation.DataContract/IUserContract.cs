using System.Collections.Generic;
using System.Linq;
using System.Text;
using Motivation.Models;

namespace Motivation.DataContract
{
    public interface IUserContract : IEntity
    {
	    string Login { get; set; }

	    string Name { get; set; }

		string UserGroupTitle { get; set; }

		bool IsGeneral { get; set; }
    }
}
