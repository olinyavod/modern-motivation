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
    public partial class CompetitionEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnAdd(object sender, EventArgs e)
        {
            int competitionId = Convert.ToInt32(Request.QueryString["CompetitionId"]);
           
            foreach (RepeaterItem item in GROUPS.Items)
            {
                int groupId = (Convert.ToInt32((item.FindControl("Id") as HiddenField).Value));

                if ((item.FindControl("WAS_CHECKED") as HiddenField).Value=="False" && (item.FindControl("IS_CHECKED") as CheckBox).Checked)
                {
                    DBUtils.ExecuteNonQuery("INSERT INTO dbo.CompititionGroup(CompititionId, UserGroupId) VALUES(@CompititionId, @UserGroupId)", new SqlParameter("CompititionId", competitionId), new SqlParameter("UserGroupId", groupId));
                }

                if ((item.FindControl("WAS_CHECKED") as HiddenField).Value == "True" && !(item.FindControl("IS_CHECKED") as CheckBox).Checked)
                {
                    DBUtils.ExecuteNonQuery("DELETE FROM dbo.CompititionGroup WHERE CompititionId = @CompititionId AND UserGroupId = @UserGroupId", new SqlParameter("CompititionId", competitionId), new SqlParameter("UserGroupId", groupId));
                }
            }
        }
    }
}