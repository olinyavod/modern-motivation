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
    public partial class Competitions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add(object sender, EventArgs e)
        {
            DBUtils.ExecuteNonQuery(@"
                INSERT INTO dbo.Compititions(
                    StartDate,
                    EndDate,
                    Comment,
                    UserId
                )
                VALUES
                (@StartDate, @EndDate, @Comment, @UserId)",
               new SqlParameter("Comment", COMMENT.Text),
               new SqlParameter("StartDate", START_DATE.Text),
               new SqlParameter("EndDate", END_DATE.Text),
               new SqlParameter("UserId", 1)
               );

            COMPETIIONS.DataBind();
        }
    }
}