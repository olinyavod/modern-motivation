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
    public partial class AchivementTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add(object sender, EventArgs e)
        {
            DBUtils.ExecuteNonQuery(@"
                INSERT INTO dbo.AchivmentType(
                    Comment,
                    MaxCount,
                    ExpCount,
                    CoinsCount
                )
                VALUES
                (@Comment, @MaxCount, @ExpCount, @CoinsCount)",
               new SqlParameter("Comment", COMMENT.Text),
               new SqlParameter("MaxCount", MAX_COUNT.Text),
               new SqlParameter("ExpCount", EXP.Text),
               new SqlParameter("CoinsCount", COINS.Text)
               );

            ACHIVEMENTS.DataBind();
        }
    }
}