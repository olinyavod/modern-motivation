using BikeRent.Web.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Motivation.Site.Pages
{
    public partial class UserGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnAddGroup(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();

            DBUtils.ExecuteNonQuery(@"
                INSERT INTO dbo.UserGroups(
                    Name
                )
                VALUES
                (@Descr)",
                    new SqlParameter("Descr", DESCR.Text));

            USER_GROUPS.DataBind();
        }
    }
}